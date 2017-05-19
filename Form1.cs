using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using GraphicalEditor.Shapes;
using GraphicalEditor.Interfaces;
using GraphicalEditor.Commands;
using GraphicalEditor.IO;
using GraphicalEditor.Strategy;
using static GraphicalEditor.Util.Enums;
using GraphicalEditor.Decorator;

namespace GraphicalEditor
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Color paintColor;
        private Color PaintColor
        {
            get
            {
                return paintColor;
            }
            set
            {
                if (value == paintColor)
                    return;

                paintColor = value;
            }
        }

        private ToolItem currentTool;
        private ToolItem CurrentTool
        {
            get
            {
                return currentTool;
            }
            set
            {
                if (value == currentTool)
                    return;

                currentTool = value;

                label_SelectedTool.Text = string.Format("Selected Tool: {0} " , currentTool.ToString());

                UpdateToolButtonsCheckedState();
            }
        }

        private Point dragMouseLocation = new Point(0, 0);
        private Rectangle previousShapeBounds = new Rectangle();
        private Rectangle newShapeBounds = new Rectangle();

        private bool isChoosingColor = false;
        private bool holdingMouseDown = false;

        private CommandHandler commandHandler;
        private DrawHandler DrawHandlerInstance { get { return DrawHandler.Instance; } }

        public Form()
        {
            InitializeComponent();

            commandHandler = new CommandHandler();
            CurrentTool = ToolItem.None;

            //Register events
            commandHandler.OnExecute += OnCommandExecute;
            commandHandler.OnUndo += OnCommandUndo;
        }

        private void UpdateHitStatus(Point currentPoint)
        {
            DrawHandlerInstance.UpdateHitstatusByCurrentPoint(currentPoint);

            SetCursor();
        }

        private void SetCursor()
        {
            if (!DrawHandlerInstance.HasSelectedAShape)
            {
                Cursor = Cursors.Default;
                return;
            }

            switch (DrawHandlerInstance.CurrentHitStatus)
            {
                case HitStatus.Drag:
                    Cursor = Cursors.SizeAll;
                    break;
                case HitStatus.ResizeBottom:
                case HitStatus.ResizeTop:
                    Cursor = Cursors.SizeNS;
                    break;
                case HitStatus.ResizeLeft:
                case HitStatus.ResizeRight:
                    Cursor = Cursors.SizeWE;
                    break;

                case HitStatus.ResizeBottomLeft:
                case HitStatus.ResizeTopRight:
                    Cursor = Cursors.SizeNESW;
                    break;

                case HitStatus.ResizeBottomRight:
                case HitStatus.ResizeTopLeft:
                    Cursor = Cursors.SizeNWSE;
                    break;

                default:
                    Cursor = Cursors.Default;
                    break;


            }
        }


        private void UpdateToolButtonsCheckedState()
        {

            Button_Brush.Checked = false;
            Button_Ellipse.Checked = false;
            Button_Line.Checked = false;
            Button_Pencil.Checked = false;
            Button_Rectangle.Checked = false;
            Button_ColorPicker.Checked = false;

            switch (CurrentTool)
            {
                case ToolItem.Brush:
                    Button_Brush.Checked = true;
                    break;

                case ToolItem.Ellipse:
                    Button_Ellipse.Checked = true;
                    break;

                case ToolItem.Line:
                    Button_Line.Checked = true;
                    break;

                case ToolItem.Pencil:
                    Button_Pencil.Checked = true;
                    break;

                case ToolItem.Rectangle:
                    Button_Rectangle.Checked = true;
                    break;

                case ToolItem.ColorPicker:
                    Button_ColorPicker.Checked = true;
                    break;

            }
        }

        # region General Events
        private void OnCommandUndo(ICommand command)
        {
            PictureBox_DrawArea.Invalidate();
        }

        private void OnCommandExecute(ICommand command)
        {
            PictureBox_DrawArea.Invalidate();
        }

        #endregion

        #region GUI General Events

        private void PictureBox_DrawArea_Paint(object sender, PaintEventArgs e)
        {
            DrawHandlerInstance.RedrawShapes(e.Graphics);
        }

        private void PictureBox_ColorPicker_MouseDown(object sender, MouseEventArgs e)
        {
            isChoosingColor = true;
        }

        private void PictureBox_ColorPicker_MouseUp(object sender, MouseEventArgs e)
        {
            isChoosingColor = false;
        }

        private void PictureBox_ColorPicker_MouseMove(object sender, MouseEventArgs e)
        {
            if (isChoosingColor)
            {
                Bitmap bmp = (Bitmap)PictureBox_ColorPicker.Image.Clone();

                if (e.X < 0 || e.Y < 0)
                    return;

                if (e.X >= bmp.Width)
                    return;

                if (e.Y >= bmp.Height)
                    return;

                PaintColor = bmp.GetPixel(e.X, e.Y);
                Trackbar_ColorPicker_Red.Value = PaintColor.R;
                Trackbar_Colorpicker_Green.Value = PaintColor.G;
                Trackbar_Colorpicker_Blue.Value = PaintColor.B;
                Trackbar_Colorpicker_Alpha.Value = PaintColor.A;
                Label_Colorpicker_redval.Text = PaintColor.R.ToString();
                Label_Colorpicker_greenval.Text = PaintColor.G.ToString();
                Label_Colorpicker_blueval.Text = PaintColor.B.ToString();
                Label_Colorpicker_alphaval.Text = PaintColor.A.ToString();
                Picturebox_CurrentColor.BackColor = PaintColor;
            }
        }

        private void Picturebox_DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            holdingMouseDown = true;

            if (DrawHandlerInstance.CurrentHitStatus == HitStatus.None)
                switch (CurrentTool)
                {
                    case ToolItem.Rectangle:

                        ShapeObject rectangle = new ShapeObject(new RectangleShape(), Constants.SHAPE_DEFAULT_WIDTH, Constants.SHAPE_DEFAULT_HEIGHT, e.Location, PaintColor);

                        commandHandler.AddCommand(new CreateShapeCommand(rectangle));

                        CurrentTool = ToolItem.None;
                        break;

                    case ToolItem.Ellipse:

                        ShapeObject ellipse = new ShapeObject(new EllipseShape(), Constants.SHAPE_DEFAULT_WIDTH, Constants.SHAPE_DEFAULT_HEIGHT, e.Location, PaintColor);

                        commandHandler.AddCommand(new CreateShapeCommand(ellipse));

                        CurrentTool = ToolItem.None;
                        break;

                    case ToolItem.None:

                        DrawHandlerInstance.SelectShapeFromPoint(e.Location);
                        break;
                }

            else if (DrawHandlerInstance.CurrentHitStatus != HitStatus.Drag)
            {
                if (DrawHandlerInstance.SelectedShape != null)
                    previousShapeBounds = DrawHandlerInstance.SelectedShape.Bounds;
            }

            dragMouseLocation = e.Location;

            UpdateHitStatus(e.Location);

            PictureBox_DrawArea.Invalidate();
        }

        private void PictureBox_DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            holdingMouseDown = false;

            if (DrawHandlerInstance.HasSelectedAShape)
                switch (CurrentTool)
                {
                    case ToolItem.Line:
                        Graphics g = PictureBox_DrawArea.CreateGraphics();
                        g.DrawLine(new Pen(new SolidBrush(PaintColor)), dragMouseLocation, e.Location);
                        g.Dispose();
                        break;

                    case ToolItem.None:

                        if (DrawHandlerInstance.CurrentHitStatus == HitStatus.Drag)
                        {
                            ICommand MoveCommand = new MoveShapeCommand(DrawHandlerInstance.SelectedShape, dragMouseLocation, e.Location);
                            commandHandler.AddCommand(MoveCommand);

                        }
                        else if (DrawHandlerInstance.CurrentHitStatus != HitStatus.None)
                        {
                            ICommand ResizeCommand = new ResizeShapeCommand(DrawHandlerInstance.SelectedShape, previousShapeBounds, newShapeBounds);
                            commandHandler.AddCommand(ResizeCommand);
                        }
                        break;
                }

            PictureBox_DrawArea.Invalidate();
        }

        private void PictureBox_DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (holdingMouseDown)
            {

                switch (CurrentTool)
                {
                    case ToolItem.None:

                        if (DrawHandlerInstance.CurrentHitStatus == HitStatus.Drag)
                            DrawHandlerInstance.MoveSelectedShape(e.Location);
                        else
                            newShapeBounds = DrawHandlerInstance.ResizeSelectedShape(e.Location);
                        break;
                }
            }
            else
                UpdateHitStatus(e.Location);
            PictureBox_DrawArea.Invalidate();
        }
        #endregion

        #region GUI Button Events
        private void Button_Brush_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.Brush;
        }

        private void Button_Rectangle_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.Rectangle;
        }

        private void Button_Ellipse_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.Ellipse;
        }

        private void Button_Pencil_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.Pencil;
        }

        private void Button_Group_Click(object sender, EventArgs e)
        {
            if (!DrawHandlerInstance.HasSelectedAShape)
                return;

            ICommand groupCommand = new GroupCommand(DrawHandlerInstance.SelectedShapes);
            commandHandler.AddCommand(groupCommand);
        }

        private void Button_line_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.Line;
        }

        private void Button_ColorPicker_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.ColorPicker;
        }

        private void Button_New_Click(object sender, EventArgs e)
        {
            PictureBox_DrawArea.Refresh();
            PictureBox_DrawArea.Image = null;
        }

        private void Button_Load_Click(object sender, EventArgs e)
        {
            SaveLoadController saveLoad = new SaveLoadController();
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Graphic files|*.graphic";
            if (o.ShowDialog() == DialogResult.OK)
            {
                commandHandler.AddCommand(new LoadCommand(DrawHandlerInstance.ShapeList, saveLoad.LoadShapes(o.FileName)));
            }
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            SaveLoadController saveLoad = new SaveLoadController();
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Graphic files|*.graphic";
            if (s.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(s.FileName))
                {
                    File.Delete(s.FileName);
                }

            saveLoad.SaveShapes(DrawHandlerInstance.ShapeList, s.FileName);
            }
        }

        private void Trackbar_ColorPicker_Red_Scroll(object sender, EventArgs e)
        {
            PaintColor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = PaintColor;
            Label_Colorpicker_redval.Text = string.Format("R: {0} ", PaintColor.R.ToString());
        }

        private void Trackbar_ColorPicker_Green_Scroll(object sender, EventArgs e)
        {
            PaintColor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = PaintColor;
            Label_Colorpicker_greenval.Text = string.Format("G: {0} " , PaintColor.G.ToString());
        }

        private void Trackbar_ColorPicker_Blue_Scroll(object sender, EventArgs e)
        {
            PaintColor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = PaintColor;
            Label_Colorpicker_blueval.Text = string.Format("B: {0} " , PaintColor.B.ToString());
        }

        private void PictureBox_DrawArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (CurrentTool == ToolItem.ColorPicker)
            {
                Bitmap bmp = new Bitmap(PictureBox_DrawArea.Width, PictureBox_DrawArea.Height);
                Graphics g = Graphics.FromImage(bmp);
                Rectangle rect = PictureBox_DrawArea.RectangleToScreen(PictureBox_DrawArea.ClientRectangle);
                g.CopyFromScreen(rect.Location, Point.Empty, PictureBox_DrawArea.Size);
                g.Dispose();
                PaintColor = bmp.GetPixel(e.X, e.Y);
                Picturebox_CurrentColor.BackColor = PaintColor;
                Trackbar_ColorPicker_Red.Value = PaintColor.R;
                Trackbar_Colorpicker_Green.Value = PaintColor.G;
                Trackbar_Colorpicker_Blue.Value = PaintColor.B;
                Trackbar_Colorpicker_Alpha.Value = PaintColor.A;
                Label_Colorpicker_redval.Text = PaintColor.R.ToString();
                Label_Colorpicker_greenval.Text = PaintColor.G.ToString();
                Label_Colorpicker_blueval.Text = PaintColor.B.ToString();
                Label_Colorpicker_alphaval.Text = PaintColor.A.ToString();
                bmp.Dispose();
            }
        }

        private void Trackbar_ColorPicker_Alpha_Scroll(object sender, EventArgs e)
        {
            PaintColor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = PaintColor;
            Label_Colorpicker_alphaval.Text = string.Format("A: {0} ", PaintColor.A.ToString());
        }

        private void Button_Undo_Click(object sender, EventArgs e)
        {
            commandHandler.Undo();
            DrawHandlerInstance.ClearSelection();
        }

        private void Button_Redo_Click(object sender, EventArgs e)
        {
            commandHandler.Redo();
            DrawHandlerInstance.ClearSelection();
        }

        private void button_Top_Decorator_Click(object sender, EventArgs e)
        {
            if (!DrawHandlerInstance.HasSelectedAShape)
                return;

            if (string.IsNullOrWhiteSpace(textbox_DecoratorText.Text))
                return;

            DrawHandlerInstance.AddDecoratorToSelectedShape(new TopDecorator(textbox_DecoratorText.Text));
        }

        private void button_Bottom_Decorator_Click(object sender, EventArgs e)
        {
            if (!DrawHandlerInstance.HasSelectedAShape)
                return;

            if (string.IsNullOrWhiteSpace(textbox_DecoratorText.Text))
                return;

            DrawHandlerInstance.AddDecoratorToSelectedShape(new BottomDecorator(textbox_DecoratorText.Text));
        }

        private void button_Left_Decorator_Click(object sender, EventArgs e)
        {
            if (!DrawHandlerInstance.HasSelectedAShape)
                return;

            if (string.IsNullOrWhiteSpace(textbox_DecoratorText.Text))
                return;

            DrawHandlerInstance.AddDecoratorToSelectedShape(new LeftDecorator(textbox_DecoratorText.Text));
        }

        private void button_Right_Decorator_Click(object sender, EventArgs e)
        {
            if (!DrawHandlerInstance.HasSelectedAShape)
                return;

            if (string.IsNullOrWhiteSpace(textbox_DecoratorText.Text))
                return;

            DrawHandlerInstance.AddDecoratorToSelectedShape(new RightDecorator(textbox_DecoratorText.Text));
        }
        #endregion


    }
}
