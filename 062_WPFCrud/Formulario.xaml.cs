using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _062_WPFCrud
{
    /// <summary>
    /// Lógica de interacción para Formulario.xaml
    /// </summary>
    public partial class Formulario : Page
    {
        public int Id = 0;
        public Formulario(int Id = 0)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != 0) 
            {
                using (Model.WPFCrudEntities db = new Model.WPFCrudEntities()) 
                {
                    var oPerson = db.person.Find(this.Id);
                    txtEdad.Text = oPerson.Age.ToString();
                    txtNombre.Text = oPerson.Name;   
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Id == 0)
            {
                using (Model.WPFCrudEntities db = new Model.WPFCrudEntities())
                {
                    var oPerson = new Model.person();
                    try
                    {
                        oPerson.Name = txtNombre.Text;
                        oPerson.Age = int.Parse(txtEdad.Text);
                        if (oPerson.Age > 0)
                        {
                            db.person.Add(oPerson);
                            db.SaveChanges();

                            MainWindow.StaticMainFrame.Content = new MenuYLista();
                        }
                        else 
                        {
                            MessageBox.Show("Edad incorrecta");
                        }
                    }
                    catch 
                    {
                        MessageBox.Show("Edad incorrecta");
                    }
                   
                }
            }
            else 
            {
                using (Model.WPFCrudEntities db = new Model.WPFCrudEntities())
                {
                    var oPerson = db.person.Find(Id);
                    try
                    {
                        oPerson.Name = txtNombre.Text;
                        oPerson.Age = int.Parse(txtEdad.Text);
                        if (oPerson.Age > 0)
                        {
                            db.person.Add(oPerson);
                            db.SaveChanges();

                            MainWindow.StaticMainFrame.Content = new MenuYLista();
                        }
                        else
                        {
                            MessageBox.Show("Edad incorrecta");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Edad incorrecta");
                    }

                    
                }
            }
        }
    }
}
