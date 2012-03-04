using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace CogitoProject.Graphics
{
    /**
     * The Insight Base Class is responsible for setting up program specific 
     * graphic features such as what is to be drawn to the DirectX buffer.
     * 
     * @author Brent Strysko
     * @date 2/11/10
     */
    public class Insight : InsightBase
    {
        private CustomVertex.PositionColored[] _vertices;

        private float _angle;
        /**
         * The same renamed constructor as InsightBase's constructor.  
         * 
         * @param position the position of the DirectX frame
         * @param size the size of the DirectX frmae
         */
        public Insight(Point position, Size size) : base(position,size)
        {
            this._vertices = new CustomVertex.PositionColored[3];
            this._angle = 0.0f;
        }

        protected override void process()
        {
            Random rand = new Random();

            Color temp1 = Color.FromArgb(0, rand.Next(255), rand.Next(255), rand.Next(255));
            Color temp2 = Color.FromArgb(0, rand.Next(255), rand.Next(255), rand.Next(255));
            Color temp3 = Color.FromArgb(0, rand.Next(255), rand.Next(255), rand.Next(255));

            _vertices[2].Position = new Vector3(0f, 0f, 0f);
            _vertices[2].Color = temp1.ToArgb();
            _vertices[0].Position = new Vector3(5f, 10f, 0f);
            _vertices[0].Color = temp2.ToArgb();
            _vertices[1].Position = new Vector3(10f, 0f, 0f);
            _vertices[1].Color = temp3.ToArgb();
            _angle += 0.1f;

        }

        /**
         * This tells what shall be written to the buffer.  Every render cycle. 
         */
        protected override void render()
        {
            device.VertexFormat = CustomVertex.PositionColored.Format;

            device.RenderState.Lighting = false;
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, this.Width / this.Height, 1f, 50f);
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 0, -30), new Vector3(0, 0, 0), new Vector3(0, 1, 0));

            device.Transform.World = Matrix.Translation(-5, -10 * 1 / 3, 0) * Matrix.RotationZ(_angle);


            device.DrawUserPrimitives(PrimitiveType.TriangleList,1, _vertices);
        }
    }
}
