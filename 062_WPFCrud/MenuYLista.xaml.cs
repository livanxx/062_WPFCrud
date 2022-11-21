using _062_WPFCrud.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _062_WPFCrud
{
    /// <summary>
    /// Lógica de interacción para MenuYLista.xaml
    /// </summary>
    public partial class MenuYLista : Page
    {
        public MenuYLista()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh() 
        {
            List<PersonViewModel> lst = new List<PersonViewModel>();
            using (PersonRepository personRepository = new PersonRepository()) 
            {
                lst = (from d in personRepository.GetAll()
                       select new PersonViewModel
                       {
                           Name = d.Name,
                           Age = d.Age,
                           Id= d.Id
                       }).ToList();
            }

            DG.ItemsSource = lst;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.StaticMainFrame.Content = new Formulario();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            using (PersonRepository personRepository = new PersonRepository()) 
            {
                var oPerson = personRepository.Get(Id);
                personRepository.Delete(oPerson);
            }
            Refresh();
        }

        private void Button_Editar(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            Formulario pFormulario = new Formulario(Id);

            MainWindow.StaticMainFrame.Content = pFormulario;
        }
    }

    public class PersonViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}
