using _062_WPFCrud.DataAccess.Context;
using _062_WPFCrud.DataAccess.Repositories;
using System.Windows;
using System.Windows.Controls;

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
                using (PersonRepository personRepository = new PersonRepository())
                {
                    var oPerson = personRepository.Get(this.Id);
                    if (oPerson != null)
                    {
                        txtEdad.Text = oPerson.Age.ToString();
                        txtNombre.Text = oPerson.Name;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al cargar los datos.");
                    }                    
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Id == 0)
            {
                using (PersonRepository personRepository = new PersonRepository())
                {
                    var oPerson = new person();
                    try
                    {
                        oPerson.Name = txtNombre.Text;
                        oPerson.Age = int.Parse(txtEdad.Text);
                        if (oPerson.Age > 0)
                        {
                            if (personRepository.Insert(oPerson))
                            {
                                MainWindow.StaticMainFrame.Content = new MenuYLista();
                                MessageBox.Show("Cambios guardados correctamente.");
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un error al guardar sus cambios.");
                            }                          
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
                using (PersonRepository personRepository = new PersonRepository())
                {
                    var oPerson = personRepository.Get(Id);
                    try
                    {
                        oPerson.Name = txtNombre.Text;
                        oPerson.Age = int.Parse(txtEdad.Text);
                        if (oPerson.Age > 0)
                        {
                            if (personRepository.Update(oPerson))
                            {
                                MainWindow.StaticMainFrame.Content = new MenuYLista();
                                MessageBox.Show("Cambios guardados correctamente.");
                            }                           
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
