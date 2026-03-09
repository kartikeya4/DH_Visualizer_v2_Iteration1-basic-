using DH_Visualizer_v2.Modal;
using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
//using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace DH_Visualizer_v2
{
    /// <summary>
    /// Interaction logic for RobotVisualizerControl.xaml
    /// </summary>
    public partial class RobotVisualizerControl : UserControl
    {
        bool World_Axis = true;
        bool Show_Grid = true;
        bool Link_Label = true;
        bool End_Effector_Position = true;

        public RobotVisualizerControl()
        {
            InitializeComponent();
        }
        public void VisualizeRobot(List<DHParameter> parameter)
        {
            Debug.WriteLine("Visualizing Robot with Parameters:");

            if (parameter == null || parameter.Count == 0) return;
            View_Port.Children.Clear();
            View_Port.Children.Add(Light_Source);

            //Base coordinate frame
            if (World_Axis) { Add_ReferenceAxis(); }
            //
            if (Show_Grid) { Add_Grid(); }
            // T =Current_Transformation matrix that changes after each dh parameter is applied
            Matrix3D T = Matrix3D.Identity;
            Point3D End_Effector = new Point3D(0, 0, 0);

            //intial point of the robot base
            Point3D p0 = new Point3D(0, 0, 0);
            for (int i = 1; i < parameter.Count+1; i++)
            {
                var param = parameter[i-1];
                if (param.Jointype == jointType.R)
                {
                    //Draw_Revolute_Ring(p0, T, linkColors[i-1 % 6]);
                    draw_sphere_joint(p0, linkColors[(i - 1) % 6],3);
                    //step 1 roatation theta around z axis
                    T = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), param.Theta)).Value * T;

                    //step 2 translation around z axis
                    T = new TranslateTransform3D(0, 0, param.LinkOffset * 10).Value * T;

                    //draw z axis link link offset (D)
                    var p1 = T.Transform(new Point3D(0, 0, 0));


                    Draw_Cylinder(p0, p1, linkColors[i % 6]);

                    if (param.LinkLength != 0)
                    {
                        draw_sphere_joint(p1, linkColors[(i) % 6],2.5);

                    }
                    ;


                    //step 3 translation around x axis
                    T = new TranslateTransform3D(param.LinkLength * 10, 0, 0).Value * T;



                    //draw x axis link length (A)
                    var p2 = T.Transform(new Point3D(0, 0, 0));
                    Draw_Cylinder(p1, p2, linkColors[i % 6]);


                    //step 4 rotation around x axis 
                    T = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), param.Alpha)).Value * T;

                }
                else
                {

                    //step 1 roatation theta around z axis
                    T = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), param.Theta)).Value * T;

                    //step 2 translation around z axis
                    T = new TranslateTransform3D(0, 0, param.LinkOffset * 10).Value * T;

                    //draw z axis link link offset (D)
                    var p1 = T.Transform(new Point3D(0, 0, 0));


                    //Draw_Prismatic_Joint(p0, p1, T, linkColors[i % 6]);
                    //Draw_Prismatic_Joint_Simple(p0, p1, linkColors[i % 6]); // sleeve + rod

                    Vector3D dir = p1 - p0;       // Vector pointing from p1 to p2
                    double length = dir.Length;    // How long the box needs to be
                    //if (length < 1e-6) return;     // Guard: skip if points are the same
                    dir.Normalize();               // Make it a unit vector (length = 1)

                    Draw_cuboid(p0, p1, linkColors[i % 6]);
                    //Draw_Cylinder(p0, p1, linkColors[i % 6]);
                    //Draw_Prismatic_Joint(p0, p1, linkColors[i % 6]);
                    //step 3 translation around x axis
                    T = new TranslateTransform3D(param.LinkLength * 10, 0, 0).Value * T;

                    //draw x axis link length (A)
                    var p2 = T.Transform(new Point3D(0, 0, 0));
                    if (param.LinkLength != 0)
                    {
                        draw_sphere_joint(p1, linkColors[(i) % 6],2.5);

                    }
                    ;
                    Draw_cuboid(p1, p2, linkColors[i % 6]);
                    //Draw_Cylinder(p1, p2, linkColors[i%6]);

                   

                    //step 4 rotation around x axis 
                    T = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), param.Alpha)).Value * T;

                }

                View_Port.Children.Add(new CoordinateSystemVisual3D
                {
                    ArrowLengths = 15,
                    Transform = new MatrixTransform3D(T)
                });
                //final point of the current link
                Point3D p_final = T.Transform(new Point3D(0, 0, 0));

                //point used as base for the next link
                p0 = p_final;
            }

        }


        //Helper functions for visualization
        private void Add_Grid()
        {
            var grid = new LinesVisual3D { Color = Colors.Gray, Thickness = 2 };
            var pts = new Point3DCollection();


            for (int i = -200; i <= 200; i += 10)
            {
                //y_axis lines
                pts.Add(new Point3D(i, 200, 0));
                pts.Add(new Point3D(i, -200, 0));
                //x_axis lines
                pts.Add(new Point3D(200, i, 0));
                pts.Add(new Point3D(-200, i, 0));



            }
            grid.Points = pts;
            View_Port.Children.Add(grid);
            //var grid = new GridLinesVisual3D
            //{
            //    Width = 20,
            //    Length = 20,
            //    MinorDistance = 1,
            //    MajorDistance = 20,
            //    Thickness = 0.1,
            //    Center = new Point3D(0, 0, 0)
            //};

            //View_Port.Children.Add(grid); }
        }

        private void Add_ReferenceAxis()
        {
            View_Port.Children.Add(new CoordinateSystemVisual3D { ArrowLengths = 25 });
        }





        private void Draw_Cylinder(Point3D p1, Point3D p2, Brush color)
        {
            View_Port.Children.Add(new PipeVisual3D
            {
                Point1 = p1,
                Point2 = p2,
                Diameter = 5,
                Fill = color
            });
        }


        private void Draw_cuboid(Point3D p1, Point3D p2, Brush color)
        {
            Vector3D dir = p2 - p1;       // Vector pointing from p1 to p2
            double length = dir.Length;    // How long the box needs to be
            if (length < 1e-6) return;     // Guard: skip if points are the same
            dir.Normalize();               // Make it a unit vector (length = 1)

            var cuboid = new BoxVisual3D
            {
                Length = length,
                Width = 5,
                Height = 5,
                Fill = color,
            };

            Vector3D x_axis = new Vector3D(1, 0, 0);

            Vector3D rotation_axis = Vector3D.CrossProduct(x_axis, dir);
            double angle = Vector3D.AngleBetween(x_axis, dir);

            Point3D center = new Point3D((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2, (p1.Z + p2.Z) / 2);

            Transform3D final_transform;
            if (rotation_axis.Length > 1e-6)
            {
                final_transform = new Transform3DGroup
                {
                    Children = new Transform3DCollection
                    {
                        new RotateTransform3D(new AxisAngleRotation3D(rotation_axis, angle)),
                        new TranslateTransform3D(center.X,center.Y,center.Z)
                    }
                };

            }
            else
            {
                double dot = Vector3D.DotProduct(x_axis, dir);
                if (dot > 0)
                {
                    //no rotation needed
                    final_transform = new TranslateTransform3D(center.X, center.Y, center.Z);

                }
                else
                {
                    final_transform = new Transform3DGroup
                    {
                        Children = new Transform3DCollection
                        {
                        new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0,0,1), 180)),
                        new TranslateTransform3D(center.X,center.Y,center.Z)
                        }
                    };

                }

            }
            cuboid.Transform = final_transform;
            View_Port.Children.Add(cuboid);


        }

       


        private Brush[] linkColors = {
            Brushes.Orange,
            Brushes.CornflowerBlue,
            Brushes.MediumSeaGreen,
            Brushes.Orchid,
            Brushes.Tomato,
            Brushes.SteelBlue
        };

        private void draw_sphere_joint(Point3D center, Brush color, double rad)
        {
            View_Port.Children.Add(new SphereVisual3D
            {
                Center = center,
                Radius = rad,
                Fill = color
            });
        }

       
        
    }
}
