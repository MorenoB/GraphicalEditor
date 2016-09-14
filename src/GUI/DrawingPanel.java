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

import drawables.Shape;
import java.awt.Graphics;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JPanel;

/**
 *
 * @author Moreno
 */
public class DrawingPanel extends JPanel {

    private List<Shape> shapes;
    private Shape lastSelectedShape;

    public DrawingPanel() {
        this.shapes = new ArrayList<>();

        MouseAdapter l = new MouseAdapter() {

            @Override
            public void mousePressed(MouseEvent e) {
                super.mousePressed(e);
                
                /*if(lastSelectedShape != null)
                {
                    lastSelectedShape.isSelected = false;
                    lastSelectedShape = null;
                }
                
                Shape selectedObj = (Shape)e.getComponent();
                
                if(selectedObj != null)
                {
                    if(shapes.contains(selectedObj))
                    {
                        selectedObj.isSelected = true;
                        lastSelectedShape = selectedObj;
                    }
                }*/
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
        };

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
}
