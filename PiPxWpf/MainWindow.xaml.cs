using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PiPxWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadWindowList();
        }

        private void LoadWindowList()
        {
            try
            {
                // Corrigido para "Process.GetProcesses" e verificação correta do título da janela
                var processes = Process.GetProcesses().Where(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));
                
                foreach (var process in processes)
                {
                    WindowsListComboBox.Items.Add(process.MainWindowTitle);
                }

                if (WindowsListComboBox.Items.Count == 0)
                {
                    MessageBox.Show("Nenhuma janela ativa encontrada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar janelas: {ex.Message}");
            }
        }

        private void StartPiP_Click(object sender, RoutedEventArgs e)
        {
            if (WindowsListComboBox.SelectedItem != null)
            {
                string selectedWindow = WindowsListComboBox.SelectedItem.ToString();
                MessageBox.Show($"Iniciando PiP para: {selectedWindow}");
            }
            else
            {
                MessageBox.Show("Selecione uma janela primeiro!");
            }
        }
    }
}
