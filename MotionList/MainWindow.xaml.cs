using Dragablz;
using System.Windows;

namespace SweetNewItemsControl
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private object[] _order;

    public MainWindow()
    {
      InitializeComponent();

      DataContext = new MainWindowViewModel();

      AddHandler(DragablzItem.DragStarted, new DragablzDragStartedEventHandler(ItemDragStarted), true);
      AddHandler(DragablzItem.DragCompleted, new DragablzDragCompletedEventHandler(ItemDragCompleted), true);
    }

    private void ItemDragStarted(object sender, DragablzDragStartedEventArgs e)
    {
      var item = e.DragablzItem.DataContext;

      System.Diagnostics.Trace.WriteLine($"User started to drag item: {item}.");
    }

    private void ItemDragCompleted(object sender, DragablzDragCompletedEventArgs e)
    {
      var item = e.DragablzItem.DataContext;
      System.Diagnostics.Trace.WriteLine($"User finished dragging item: {item}.");

      if (_order == null) return;

      System.Diagnostics.Trace.Write("Order is now: ");
      foreach (var i in _order)
      {
        System.Diagnostics.Trace.Write(i + " ");
      }
      System.Diagnostics.Trace.WriteLine("");
    }

    private void StackPositionMonitor_OnOrderChanged(object sender, OrderChangedEventArgs e)
    {
      _order = e.NewOrder;
    }

  }
}
