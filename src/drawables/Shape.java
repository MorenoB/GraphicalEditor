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

    private final int POINT_SIZE = 7;

    private final ShapeResizeHandler customMouseListener = new ShapeResizeHandler();

    private final List<Rectangle2D> points = new ArrayList<>();
    private final Rectangle2D selectedRectangle = new Rectangle2D.Double();
    
    public boolean isSelected = false;

    public Shape(int x, int y, int width, int height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        
        int pointXLoc = x - POINT_SIZE/2;
        int pointYLoc = y - POINT_SIZE/2;

        Rectangle2D r1 = new Rectangle2D.Double(pointXLoc, pointYLoc, POINT_SIZE, POINT_SIZE);
        Rectangle2D r2 = new Rectangle2D.Double(pointXLoc + width, pointYLoc + height, POINT_SIZE, POINT_SIZE);

        points.add(r1);
        points.add(r2);

    }

    public void draw(Graphics g) {

        Graphics2D g2 = (Graphics2D) g;
        
        Rectangle2D firstPoint = points.get(0);
        Rectangle2D secondPoint = points.get(1);
        
        selectedRectangle.setRect(firstPoint.getCenterX(), firstPoint.getCenterY(),
                Math.abs(firstPoint.getCenterX() - secondPoint.getCenterX()),
                Math.abs(firstPoint.getCenterY() - secondPoint.getCenterY()));

        this.x = (int) selectedRectangle.getX();
        this.y = (int) selectedRectangle.getY();
        this.width = (int) selectedRectangle.getWidth();
        this.height = (int) selectedRectangle.getHeight();
        
        if(isSelected)
            ResizeShape(g2);

    }
    
    private void ResizeShape(Graphics2D g2)
    {
        for (Rectangle2D point : points) {
            g2.fill(point);
        }
        
        g2.draw(selectedRectangle);
    }
    
    public boolean IsInsideSelectedRectangle(Point p)
    {
        if(selectedRectangle == null)
        {
            System.out.println("Object has no selectable rectangle!");
            return false;
        }
        return selectedRectangle.contains(p);
    }

    public ShapeResizeHandler GetMouseListener() {
        return customMouseListener;
    }

    class ShapeResizeHandler extends MouseAdapter {

        private int pos = -1;

        @Override
        public void mousePressed(MouseEvent event) {
            super.mousePressed(event);

            Point p = event.getPoint();
            for (int i = 0; i < points.size(); i++) {
                if (points.get(i).contains(p)) {
                    pos = i;
                    System.out.println("Selected point " + i);
                    return;
                }
            }
        }

        @Override
        public void mouseReleased(MouseEvent event) {
            super.mouseReleased(event);

            pos = -1;
        }

        @Override
        public void mouseDragged(MouseEvent event) {
            super.mouseDragged(event);

            if (pos == -1) {
                return;
            }

            Rectangle2D point = points.get(pos);
            Point selectedPoint = event.getPoint();
            if (point == null || selectedPoint == null) {
                return;
            }
            
            x = selectedPoint.x;
            y = selectedPoint.y;

            point.setRect(selectedPoint.x, selectedPoint.y, point.getWidth(),
                    point.getHeight());
            
            repaint();
        }
    }
}
