/*
 * The MIT License
 *
 * Copyright 2015 Moreno.
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

import javax.swing.JPanel;

/**
 *
 * @author Moreno
 */
public class Drawable extends JPanel {

    private final int SIZE = 8;
    private final Rectangle2D[] points = {new Rectangle2D.Double(50, 50, SIZE, SIZE), new Rectangle2D.Double(150, 100, SIZE, SIZE)};
    Rectangle2D s = new Rectangle2D.Double();
    ShapeResizeHandler ada = new ShapeResizeHandler();

    public Drawable() {
        addMouseListener(ada);
        addMouseMotionListener(ada);
    }

    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);

        Graphics2D g2 = (Graphics2D) g;

        for (Rectangle2D point : points) {
            g2.fill(point);
        }
        s.setRect(points[0].getCenterX(), points[0].getCenterY(),
                Math.abs(points[1].getCenterX() - points[0].getCenterX()),
                Math.abs(points[1].getCenterY() - points[0].getCenterY()));

        g2.draw(s);
    }
    


    class ShapeResizeHandler extends MouseAdapter {
        Rectangle2D r = new Rectangle2D.Double(0, 0, SIZE, SIZE);
        private int pos = -1;

        @Override
        public void mousePressed(MouseEvent event) {
            Point p = event.getPoint();

            for (int i = 0; i < points.length; i++) {
                if (points[i].contains(p)) {
                    pos = i;
                    return;
                }
            }
        }

        @Override
        public void mouseReleased(MouseEvent event) {
            pos = -1;
        }

        @Override
        public void mouseDragged(MouseEvent event) {
            if (pos == -1) {
                return;
            }

            points[pos].setRect(event.getPoint().x, event.getPoint().y, points[pos].getWidth(),
                    points[pos].getHeight());
            repaint();
        }
    }
}