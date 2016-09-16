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
package GUI;

import drawables.Circle;
import drawables.Rectangle;
import drawables.Shape;
import java.awt.Graphics;
import java.awt.Point;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JPanel;

/**
 *
 * @author Moreno
 */
public class DrawingPanel extends JPanel {

    private final List<Shape> shapes;
    private Shape lastSelectedShape;

    public enum ChosenTool {
        NONE, SELECT, CREATE_RECTANGLE, CREATE_CIRCLE
    }
    public ChosenTool CurrentToolMode = ChosenTool.NONE;

    public DrawingPanel() {
        this.shapes = new ArrayList<>();

        MouseAdapter l = new MouseHandler();

        addMouseListener(l);
        addMouseMotionListener(l);

    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        for (Shape shape : shapes) {
            shape.draw(g);
        }
    }

    public void AddShape(Shape shape) {

        MouseAdapter mouseListener = shape.GetMouseListener();

        addMouseListener(mouseListener);
        addMouseMotionListener(mouseListener);

        shapes.add(shape);
        repaint();
    }

    private void SelectAtPoint(Point selectedPoint) {

        if (lastSelectedShape != null) {
            lastSelectedShape.isSelected = false;
            lastSelectedShape = null;
        }

        if (selectedPoint == null) {
            return;
        }

        for (Shape shape : shapes) {

            if (shape.IsInsideSelectedRectangle(selectedPoint)) {
                System.out.print(shape);
                if (lastSelectedShape != shape) {
                    lastSelectedShape = shape;
                    lastSelectedShape.isSelected = true;
                } else {
                    //Already selected
                }
                break;
            }
        }

    }

    class MouseHandler extends MouseAdapter {

        @Override
        public void mousePressed(MouseEvent e) {
            super.mousePressed(e);

            Point selectedPoint = e.getPoint();
            
            //Go back to default mode
            if(e.getButton() == MouseEvent.BUTTON2)
                CurrentToolMode = ChosenTool.NONE;

            switch (CurrentToolMode) {
                case NONE:
                    break;
                case SELECT:
                    SelectAtPoint(selectedPoint);
                    break;
                case CREATE_CIRCLE:

                    Circle circle = new Circle(selectedPoint.x, selectedPoint.y, 50, 50);

                    AddShape(circle);
                    break;
                case CREATE_RECTANGLE:
                    Rectangle rectangle = new Rectangle(selectedPoint.x, selectedPoint.y, 50, 50);

                    AddShape(rectangle);
                    break;
            }

            repaint();
        }

        @Override
        public void mouseReleased(MouseEvent e) {
            super.mouseReleased(e);
            repaint();
        }

        @Override
        public void mouseDragged(MouseEvent e) {
            super.mouseDragged(e);
            repaint();
        }
    }
}
