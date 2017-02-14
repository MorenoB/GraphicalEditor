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
package GUI;

/**
 *
 * @author Moreno
 */
public class Editor extends javax.swing.JFrame {

    //private GraphicArea graphicArea;
    /**
     * Creates new form Editor
     */
    public Editor() {
        initComponents();
        
        panel_DrawArea.SetStatusLabel(label_StatusLabel);
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        button_RectangleTool = new javax.swing.JButton();
        button_CirclelTool = new javax.swing.JButton();
        label_CreationTools = new javax.swing.JLabel();
        panel_DrawArea = new GUI.DrawingPanel();
        jSeparator1 = new javax.swing.JSeparator();
        label_SelectionTools = new javax.swing.JLabel();
        button_SelectionTool = new javax.swing.JButton();
        label_StatusLabel = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        button_RectangleTool.setText("Rectangle");
        button_RectangleTool.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                button_RectangleToolActionPerformed(evt);
            }
        });

        button_CirclelTool.setText("Circle");
        button_CirclelTool.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                button_CirclelToolActionPerformed(evt);
            }
        });

        label_CreationTools.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        label_CreationTools.setText("Creation");

        panel_DrawArea.setBorder(javax.swing.BorderFactory.createTitledBorder(""));

        javax.swing.GroupLayout panel_DrawAreaLayout = new javax.swing.GroupLayout(panel_DrawArea);
        panel_DrawArea.setLayout(panel_DrawAreaLayout);
        panel_DrawAreaLayout.setHorizontalGroup(
            panel_DrawAreaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 548, Short.MAX_VALUE)
        );
        panel_DrawAreaLayout.setVerticalGroup(
            panel_DrawAreaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 286, Short.MAX_VALUE)
        );

        label_SelectionTools.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        label_SelectionTools.setText("Selection");

        button_SelectionTool.setText("Select");
        button_SelectionTool.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                button_SelectionToolActionPerformed(evt);
            }
        });

        label_StatusLabel.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        label_StatusLabel.setText("Status Label!");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(button_CirclelTool, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(button_RectangleTool, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(label_CreationTools, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(jSeparator1)
                            .addComponent(label_SelectionTools, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(button_SelectionTool, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(panel_DrawArea, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                    .addComponent(label_StatusLabel, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 653, Short.MAX_VALUE))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(label_SelectionTools)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(button_SelectionTool)
                        .addGap(35, 35, 35)
                        .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, 10, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(label_CreationTools)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(button_RectangleTool)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(button_CirclelTool))
                    .addComponent(panel_DrawArea, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(label_StatusLabel, javax.swing.GroupLayout.PREFERRED_SIZE, 16, javax.swing.GroupLayout.PREFERRED_SIZE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void button_RectangleToolActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_button_RectangleToolActionPerformed
        
        ChangeTool(DrawingPanel.ChosenTool.CREATE_RECTANGLE);        
    }//GEN-LAST:event_button_RectangleToolActionPerformed

    private void button_CirclelToolActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_button_CirclelToolActionPerformed
        
        ChangeTool(DrawingPanel.ChosenTool.CREATE_CIRCLE);
    }//GEN-LAST:event_button_CirclelToolActionPerformed

    private void button_SelectionToolActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_button_SelectionToolActionPerformed
        ChangeTool(DrawingPanel.ChosenTool.SELECT);
    }//GEN-LAST:event_button_SelectionToolActionPerformed
    
    private void ChangeTool(DrawingPanel.ChosenTool newTool) {
        panel_DrawArea.CurrentToolMode = newTool;
        OnToolChanged();
    }
    
    private void OnToolChanged() {
        String statusLabelTxt = null;
        //Update status label
        switch (panel_DrawArea.CurrentToolMode) {
            case NONE:
                break;
            case CREATE_CIRCLE:
                statusLabelTxt = "Circle tool.";
                break;
            case CREATE_RECTANGLE:
                statusLabelTxt = "Rectangle tool.";
                break;
            case SELECT:
                statusLabelTxt = "Selection tool.";
                break;
        }
        
        label_StatusLabel.setText(statusLabelTxt);
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(Editor.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Editor.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Editor.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Editor.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                new Editor().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton button_CirclelTool;
    private javax.swing.JButton button_RectangleTool;
    private javax.swing.JButton button_SelectionTool;
    private javax.swing.JSeparator jSeparator1;
    private javax.swing.JLabel label_CreationTools;
    private javax.swing.JLabel label_SelectionTools;
    private javax.swing.JLabel label_StatusLabel;
    private GUI.DrawingPanel panel_DrawArea;
    // End of variables declaration//GEN-END:variables
}
