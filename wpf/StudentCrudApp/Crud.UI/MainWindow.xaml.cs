using System.Windows;
using System.Windows.Controls;
using Crud.Domain.Models;
using Crud.EFCore.Services;
using Microsoft.IdentityModel.Tokens;

namespace Crud.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StudentCrudService _studentCrudService;

        public MainWindow()
        {
            InitializeComponent();
            _studentCrudService = new StudentCrudService();
        }

        private async void AddStudent(object sender, RoutedEventArgs e)
        {
            try
            {
                await _studentCrudService.Add(TxtStudentName.Text, TxtStudentCourse.Text);
                MessageBox.Show("Student successfully added");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                ClearForm();
                FormFocus();
                await ListInternal();
            }
        }

        private void ClearForm()
        {
            TxtStudentId.Clear();
            TxtStudentName.Clear();
            TxtStudentCourse.Clear();
        }

        private void FormFocus()
        {
            TxtStudentId.Focus();
        }

        private async void DeleteStudent(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtStudentId.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("Please select the student you want to delete");
                    return;
                }

                await _studentCrudService.DeleteById(int.Parse(TxtStudentId.Text));
                MessageBox.Show("Delete successful");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                await ListInternal();
            }
        }

        private async void UpdateStudent(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtStudentId.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("Please select the student you want to update");
                    return;
                }

                await _studentCrudService.Update(
                    int.Parse(TxtStudentId.Text), TxtStudentName.Text, TxtStudentCourse.Text
                );
                MessageBox.Show("Update successful");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                await ListInternal();
            }
        }

        private async void Search(object sender, RoutedEventArgs e)
        {
            StudentDataGrid.ItemsSource = await _studentCrudService.GetAllByName(TxtStudentName.Text);
        }

        private async void List(object sender, RoutedEventArgs e)
        {
            try
            {
                await ListInternal();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SelectStudent(object sender, SelectionChangedEventArgs e)
        {
            if (StudentDataGrid.CurrentItem is not Student student)
            {
                return;
            }

            TxtStudentId.Text = student.Id.ToString();
            TxtStudentName.Text = student.Name;
            TxtStudentCourse.Text = student.Course;
        }

        /// <summary>
        /// 查询学生列表
        /// </summary>
        /// <returns>学生列表</returns>
        private async Task ListInternal()
        {
            var students = await _studentCrudService.GetAll();
            StudentDataGrid.ItemsSource = students;
        }
    }
}