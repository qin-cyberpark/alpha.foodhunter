using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace FoodHunterAlpha.Models
{
    public class ReceiptFont
    {
        private ReceiptFont() { }
        public static Font Font16 = new Font("MS Gothic", 16, FontStyle.Bold);
        public static Font Font20 = new Font("MS Gothic", 20, FontStyle.Bold);
        public static Font Font24 = new Font("MS Gothic", 24, FontStyle.Bold);
        public static Font Font28 = new Font("MS Gothic", 28, FontStyle.Bold);
        public static Font Font32 = new Font("MS Gothic", 32, FontStyle.Bold);

        public enum Fonts { FONT16, FONT20, FONT24, FONT28, FONT32 }
        public static int CharsInRow(Font font)
        {
            switch ((int)font.Size)
            {
                case 16: return 33;
                case 20: return 26;
                case 24: return 22;
                case 28: return 19;
                case 32: return 16;
            }

            return 0;
        }

        public static float FontHeight(Font font)
        {
            switch ((int)font.Size)
            {
                case 16: return 24;
                case 20: return 30;
                case 24: return 36;
                case 28: return 42;
                case 32: return 48;
            }

            return 0;
        }
    }
    public class ReceiptSpace
    {
        public ReceiptSpace() { }
        public ReceiptSpace(float top, float right, float bottom, float left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }
        public float Top { get; set; } = 0.0f;
        public float Right { get; set; } = 0.0f;
        public float Bottom { get; set; } = 0.0f;
        public float Left { get; set; } = 0.0f;
    }

    public class ReceiptRow
    {
        public ReceiptRow(string text, Font font)
        {
            Text = text;
            Font = font;
        }
        public ReceiptRow(string textLeft, string textRight, Font font)
        {
            var padLen = ReceiptFont.CharsInRow(font) - textLeft.Length - textRight.Length;
            var padStr = "";
            if(padLen > 0)
            {
                padStr = padStr.PadRight(padLen, ' ');
            }
            Text = textLeft + padStr + textRight;
            Font = font;
        }
        public string Text { get; set; }
        public Font Font { get; set; }
        public ReceiptSpace Padding { get; set; } = new ReceiptSpace();
        public float Height
        {
            get
            {
                return ReceiptFont.FontHeight(Font) + Padding.Top + Padding.Bottom;
            }
        }
    }
    public class Receipt
    {
        private const int MAX_WIDTH = 384;

        private IList<ReceiptRow> _rows = new List<ReceiptRow>();
        public void AddRow(ReceiptRow row)
        {
            _rows.Add(row);
        }
        public void AddRow(string text, Font font)
        {
            _rows.Add(new ReceiptRow(text, font));
        }
        public void AddRow(string left, string right, Font font)
        {
            _rows.Add(new ReceiptRow(left, right, font));
        }

        public Receipt(Order order)
        {
            //order number
            AddRow(string.Format("#{0}", order.Id), ReceiptFont.Font28);

            //order time
            AddRow(string.Format("{0:HH:mm:ss ddMMM, yyyy}", order.OrderTime), ReceiptFont.Font16);

            if (order.Type == Order.OrderType.DineIn)
            {
                //table
                var r = new ReceiptRow(string.Format("TABLE #{0}", order.TableNumber), ReceiptFont.Font28);
                r.Padding.Top = 20;

                AddRow(r);
            }
            else
            {
                //pick-up time
                var r = new ReceiptRow(string.Format("PICK-UP @{0:HH:mm}", order.PickupTime), ReceiptFont.Font28);
                r.Padding.Top = 20;
                AddRow(r);
            }

            //separator
            AddRow("".PadRight(ReceiptFont.CharsInRow(ReceiptFont.Font24), '-'), ReceiptFont.Font24);

            //detail
            foreach (var item in order.Items)
            {
                AddRow(string.Format("{0}x {1}", item.Quantity, item.Item.Description),
                        string.Format("{0:$0.00}", item.Item.Price * item.Quantity), ReceiptFont.Font20);
                AddRow(string.Format("    {0}","Regular"), ReceiptFont.Font16);

            }

            //separator
            AddRow("".PadRight(ReceiptFont.CharsInRow(ReceiptFont.Font24), '-'), ReceiptFont.Font24);

            //total
            AddRow("Total",string.Format("{0:$0.00}", order.Total), ReceiptFont.Font28);

            //gst
            AddRow("GST", string.Format("{0:$0.00}", order.GST), ReceiptFont.Font24);

        }

        public float Height
        {
            get
            {
                float height = 0;
                foreach (var r in _rows)
                {
                    height += r.Height + r.Padding.Top + r.Padding.Bottom ;
                }

                return height;
            }
        }

        public Bitmap Image
        {
            get
            {
                float currY = 0;
                Bitmap bmp = new Bitmap(MAX_WIDTH, (int)Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    foreach (var r in _rows)
                    {
                        currY += r.Padding.Top;
                        g.DrawString(r.Text, r.Font, Brushes.Black, 0, currY);
                        currY += r.Height + r.Padding.Bottom;
                    }
                }

                return bmp;
            }
        }

    }
}