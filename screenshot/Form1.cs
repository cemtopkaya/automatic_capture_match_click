using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Automation;
using System.Globalization;
using Gma.System.MouseKeyHook;
using System.Diagnostics.Tracing;
using System.Drawing.Drawing2D;

namespace screenshot
{

    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        public Form1()
        {
            InitializeComponent();
            BindProcess();
        }

        Rectangle rect;

        private void btnYakala_Click(object sender, EventArgs e)
        {
            captureMaster();
        }
        private void btnCaptureInstantPattern_Click(object sender, EventArgs e)
        {
            captureInstantly();
        }

        public static List<bool> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();
            //create new image with 16x16 pixel
            Bitmap bmpMin = bmpSource;// new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //reduce colors to true / false                
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }

        private void Form1_Move(object sender, EventArgs e)
        {
        }

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        private void btnHash_Click(object sender, EventArgs e)
        {
            proc();
        }


        void captureMaster()
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        //g.CopyFromScreen(int.Parse(txtX.Text), int.Parse(txtY.Text), 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
                        g.CopyFromScreen(x1, y1, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
                    }
                    pbMaster.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.DontCare);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("İStisna: " + ex);
            }
        }

        void captureInstantly()
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(x1, y1, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
                    }

                    pbLastCaptured.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.DontCare);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("İStisna: " + ex);
            }
        }
        void proc()
        {
            if (isSame())
            {
                //this.Text = "Aynı";
                //string hexCode = txtHandle.Text.Replace("0x", "");
                if (int.TryParse(txtClickX.Text, out int clickX)
                    && int.TryParse(txtClickY.Text, out int clickY))
                {
                    if (cbProcs.SelectedIndex == -1)
                    {
                        MessageBox.Show("Hangi pencereye tıklanacağını seçmelisiniz!");
                        cbProcs.Focus();
                    }
                    var iptHandle = (cbProcs.SelectedItem as Process).Handle;
                    ClickOnPointTool.ClickOnPoint(iptHandle, new Point(clickX, clickY));
                    pbLastCaptured.Image = null;
                }
            }
            else
            {
                //this.Text = "Farklı";
            }
        }

        private bool isSame()
        {
            var hashMaster = GetHash(new Bitmap(pbMaster.Image));
            if (pbLastCaptured.Image == null) captureInstantly();
            var hashInstant = GetHash(new Bitmap(pbLastCaptured.Image));
            int equalElements = hashMaster.Zip(hashInstant, (i, j) => i == j).Count(eq => eq);

            return hashMaster.Count == equalElements;
        }

        private void timerAuto_Tick(object sender, EventArgs e)
        {
            captureInstantly();
            proc();
        }

        private void cbOtomatik_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOtomatik.Checked)
            {
                if (int.TryParse(txtInterval.Text, out int interval))
                {
                    timerAuto.Stop();
                    timerAuto.Interval = interval;
                    timerAuto.Start();
                }
            }
            else
            {
                timerAuto.Stop();
            }
        }

        //******************************

        [DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        IntPtr desktopPtr;
        Graphics CreateGraphics()
        {
            desktopPtr = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopPtr);

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            return g;
        }
        void draw(int x1, int y1, int x2, int y2)
        {
            SolidBrush brush = new SolidBrush(Color.Red);
            Pen pen = new Pen(brush) { Width = 2 };
            //g.FillRectangle(b, new Rectangle(x1, y1, Math.Abs(x2 - x1), Math.Abs(y2 - y1)));
            //new Rectangle(x1, y1, x2 - x1, y2 - y1)
            var g = CreateGraphics();
            //InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
            //g.DrawRectangle(pen, rect);
            g.FillRectangle(brush, rect);
           
            
            brush.Dispose();
            pen.Dispose();
            g.Dispose();
            ReleaseDC(IntPtr.Zero, desktopPtr);
        }


        bool drawStarted = false;
        int x1, y1;
        int x2, y2;
        private void OnMouseDragStarted(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            rect = new Rectangle(e.Location, new Size() { Height = 1, Width = 1 });
            txtX1.Text = x1.ToString();
            txtY1.Text = y1.ToString();
            drawStarted = true;
            Console.WriteLine("OnMouseDragStarted: \t{0}; \t x: \t{1}, \t y: \t{2},", e.Button, e.X, e.Y);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(POINT Point);

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle(IntPtr handle)
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        private void OnMouseDragFinished(object sender, MouseEventArgs e)
        {
            BindProcess();

            IntPtr handle = WindowFromPoint(new POINT { x = e.X, y = e.Y });
            string activeWindowTitle = GetActiveWindowTitle(handle);
            for (var i = 0; activeWindowTitle != null && i < cbProcs.Items.Count; i++)
            {
                var p = cbProcs.Items[i] as Process;

                try
                {
                    if (p != null && p.MainWindowTitle == activeWindowTitle)
                    {
                        cbProcs.SelectedIndex = i;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    // yetkisiz erişimler istisna fırlatacağı için
                }
            }

            drawStarted = false;
            draw(x1, y1, e.X, e.Y);
            x2 = e.X;
            y2 = e.Y;
            txtX2.Text = x2.ToString();
            txtY2.Text = y2.ToString();
            rect = new Rectangle(x1, y1, x2 - x1, y2 - y1);
            cbPatternPosition.Checked = false;

            InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
            captureMaster();
            Console.WriteLine("OnMouseDragFinished: \t{0}; \t x: \t{1}, \t y: \t{2},", e.Button, e.X, e.Y);
        }


        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine("M_Events_MouseMove: \t{0}; \t x: \t{1}, \t y: \t{2},", e.Button, e.X, e.Y);
            if (drawStarted)
            {
                rect.Size  = new Size(e.Location.X - rect.X, e.Location.Y - rect.Y);
                draw(x1, y1, e.X, e.Y);
            }
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("KeyPress: \t{0}", e.KeyChar);
        }

        IKeyboardMouseEvents events;
        private void cbPatternPosition_CheckedChanged(object sender, EventArgs e)
        {
            CreateEvents();
            if (cbPatternPosition.Checked)
            {
                events.MouseMove += OnMouseMove;
                events.MouseDragStarted += OnMouseDragStarted;
                events.MouseDragFinished += OnMouseDragFinished;
            }
            else
            {
                Unsubscribe();
            }
        }

        private void Unsubscribe()
        {
            if (events == null) return;
            events.MouseMove -= OnMouseMove;
            events.MouseDragStarted -= OnMouseDragStarted;
            events.MouseDragFinished -= OnMouseDragFinished;
            events.MouseClick -= Events_MouseClick;
            events.Dispose();
            events = null;
        }

        void CreateEvents()
        {
            if (events == null)
                events = Hook.GlobalEvents();
        }

        void BindProcess()
        {
            cbProcs.Items.Clear();
            var arrProcs = Process.GetProcesses().Where(p => p.MainWindowTitle != "");
            cbProcs.Items.AddRange(arrProcs.ToArray());
            cbProcs.DisplayMember = "MainWindowTitle";
            cbProcs.ValueMember = "Handle";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindProcess();
        }

        private void cbClickPosition_CheckedChanged(object sender, EventArgs e)
        {
            CreateEvents();
            if (cbClickPosition.Checked)
            {
                events.MouseClick += Events_MouseClick;
            }
            else
            {
                Unsubscribe();
            }
        }

        private void Events_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Events_MouseClick: \t{0}; \t x: \t{1}, \t y: \t{2},", e.Button, e.X, e.Y);
            txtClickX.Text = e.X.ToString();
            txtClickY.Text = e.Y.ToString();
            if (events != null)
            {
                events.MouseClick -= Events_MouseClick;
                cbClickPosition.Checked = false;
            }
        }


    }

    public class ClickOnPointTool
    {

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

#pragma warning disable 649
        internal struct INPUT
        {
            public UInt32 Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public MOUSEINPUT Mouse;
        }

        internal struct MOUSEINPUT
        {
            public Int32 X;
            public Int32 Y;
            public UInt32 MouseData;
            public UInt32 Flags;
            public UInt32 Time;
            public IntPtr ExtraInfo;
        }

#pragma warning restore 649

        public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint)
        {
            var oldPos = Cursor.Position;

            /// get screen coordinates
            //ClientToScreen(wndHandle, ref clientPoint);

            /// set cursor on coords, and press mouse
            Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

            var inputMouseDown = new INPUT();
            inputMouseDown.Type = 0; /// input type mouse
            inputMouseDown.Data.Mouse.Flags = 0x0002; /// left button down

            var inputMouseUp = new INPUT();
            inputMouseUp.Type = 0; /// input type mouse
            inputMouseUp.Data.Mouse.Flags = 0x0004; /// left button up

            var inputs = new INPUT[] { inputMouseDown, inputMouseUp };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

            /// return mouse 
            Cursor.Position = oldPos;
        }

    }

    public class WindowHandleInfo
    {
        private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

        private IntPtr _MainHandle;

        public WindowHandleInfo(IntPtr handle)
        {
            this._MainHandle = handle;
        }

        public List<IntPtr> GetAllChildHandles()
        {
            List<IntPtr> childHandles = new List<IntPtr>();

            GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
            IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);

            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(this._MainHandle, childProc, pointerChildHandlesList);
            }
            finally
            {
                gcChildhandlesList.Free();
            }

            return childHandles;
        }

        private bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);

            if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
            {
                return false;
            }

            List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
            childHandles.Add(hWnd);

            return true;
        }
    }



}
