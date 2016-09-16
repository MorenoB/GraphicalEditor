/*
 * The MIT License
 *
 * Copyright 2016 Moreno.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
package drawables;

import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Point;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.geom.Rectangle2D;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JComponent;

/**
 *
 * @author Moreno
 */
public abstract class Shape extends JComponent {

    protected int x, y, width, height;

    private final int POINT_SIZE = 9;

    private final MouseHandler customMouseListener = new MouseHandler();

    private final List<Rectangle2D> scalePoints = new ArrayList<>();
    private final Rectangle2D selectedRectangle = new Rectangle2D.Double();

    public boolean isSelected = false;

    private boolean isInitScaling = false;
    public boolean isScaling = false;
    public boolean isMoving = false;

    public Shape(int x, int y, int width, int height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;

        Point pointLoc = CalculatePointLocation();

        Rectangle2D r1 = new Rectangle2D.Double(pointLoc.x, pointLoc.y, POINT_SIZE, POINT_SIZE);
        Rectangle2D r2 = new Rectangle2D.Double(pointLoc.x + width, pointLoc.y + height, POINT_SIZE, POINT_SIZE);

        scalePoints.add(r1);
        scalePoints.add(r2);

    }

    public void draw(Graphics g) {

        System.out.println("IsSelected " + isSelected + " is moving " + isMoving + " isresizing " + isScaling);

        Graphics2D g2 = (Graphics2D) g;

        if (isMoving && !isScaling) {
            Point pointLoc = CalculatePointLocation();

            Rectangle2D newFirstPoint = new Rectangle2D.Double(pointLoc.x, pointLoc.y, POINT_SIZE, POINT_SIZE);
            Rectangle2D newSecondPoint = new Rectangle2D.Double(pointLoc.x + width, pointLoc.y + height, POINT_SIZE, POINT_SIZE);

            scalePoints.set(0, newFirstPoint);
            scalePoints.set(1, newSecondPoint);
        }

        Rectangle2D firstPoint = scalePoints.get(0);
        Rectangle2D secondPoint = scalePoints.get(1);

        selectedRectangle.setRect(firstPoint.getCenterX(), firstPoint.getCenterY(),
                Math.abs(firstPoint.getCenterX() - secondPoint.getCenterX()),
                Math.abs(firstPoint.getCenterY() - secondPoint.getCenterY()));

        if (isSelected) {
            DrawSelectedRectangle(g2);
        }

        if (isScaling && !isMoving) {
            this.x = (int) selectedRectangle.getX();
            this.y = (int) selectedRectangle.getY();
            this.width = (int) selectedRectangle.getWidth();
            this.height = (int) selectedRectangle.getHeight();
        }

    }

    public void ForceInitialScaling() {
        isSelected = true;
        isScaling = true;
        isInitScaling = true;
    }

    public boolean IsInsideSelectedRectangle(Point p) {
        if (selectedRectangle == null) {
            System.out.println("Object has no selectable rectangle!");
            return false;
        }
        return selectedRectangle.contains(p);
    }

    public MouseHandler GetMouseListener() {
        return customMouseListener;
    }

    private Point CalculatePointLocation() {
        int X = x - POINT_SIZE / 2;
        int Y = y - POINT_SIZE / 2;
        Point pointLoc = new Point(X, Y);

        return pointLoc;
    }

    private void DrawSelectedRectangle(Graphics2D g2) {
        for (Rectangle2D point : scalePoints) {
            g2.fill(point);
        }

        g2.draw(selectedRectangle);
    }

    class MouseHandler extends MouseAdapter {

        private int pos = -1;

        @Override
        public void mousePressed(MouseEvent event) {
            super.mousePressed(event);

            if (!isSelected) {
                return;
            }

            Point pressedPoint = event.getPoint();

            //Check wether user has pressed a point
            for (int i = 0; i < scalePoints.size(); i++) {
                if (scalePoints.get(i).contains(pressedPoint)) {
                    pos = i;
                    isScaling = true;
                    return;
                }
            }

            isMoving = true;
        }

        @Override
        public void mouseReleased(MouseEvent event) {
            super.mouseReleased(event);

            pos = -1;
            isMoving = false;
            isScaling = false;
            isInitScaling = false;
        }

        @Override
        public void mouseDragged(MouseEvent event) {
            super.mouseDragged(event);

            if (!isSelected) {
                return;
            }

            Point selectedPoint = event.getPoint();

            if (selectedPoint == null) {
                return;
            }

            if (isInitScaling) {
                Rectangle2D secondScalePoint = scalePoints.get(1);

                if (secondScalePoint != null) {
                    secondScalePoint.setRect(selectedPoint.x,
                            selectedPoint.y,
                            secondScalePoint.getWidth(),
                            secondScalePoint.getHeight());
                }
                return;
            }

            if (isMoving) {
                x = selectedPoint.x;
                y = selectedPoint.y;
            }

            if (pos != -1) {
                Rectangle2D scalePoint = scalePoints.get(pos);

                if (scalePoint != null) {
                    scalePoint.setRect(selectedPoint.x,
                            selectedPoint.y,
                            scalePoint.getWidth(),
                            scalePoint.getHeight());
                }
            }

            repaint();
        }
    }
}
