using O2NextGen.SmallTalk.Core.ViewModels;
using Xamarin.Forms;

namespace O2NextGen.SmallTalk.Core.Views
{

    public partial class ChatDetailView : ContentPageBase
    {
        public ChatDetailView()
        {
            InitializeComponent();
        }

        //protected override void OnBindingContextChanged()
        //{
        //    base.OnBindingContextChanged();
        //    if (this.BindingContext == null)
        //        return;
        //    var context = this.BindingContext as ChatDetailViewModel;
        //    //if (context.Messages.Count == 0)
        //    //{
        //    //    context.LoadItemsCommand.Execute(null);
        //    //}
        //    if (context.Messages == null)
        //        return;
        //    context.Messages.CollectionChanged += (sender, e) =>
        //    {
        //        //GET SCROLL CURRENT POSITION HERE!
        //        var target = context.Messages[context.Messages.Count - 1];

        //        ItemsListView.ScrollTo(target, ScrollToPosition.End, false);
        //    };
        //}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //if (this.BindingContext == null)
            //    return;
            //var context = this.BindingContext as ChatDetailViewModel;
            //context.PropertyChanged += (sender, e) =>
            //{
            //    if (context.Messages == null)
            //        return;
            //    //GET SCROLL CURRENT POSITION HERE!
            //    var target = context.Messages[context.Messages.Count - 1];

            //    ItemsListView.ScrollTo(target, ScrollToPosition.End, true);
            //};
        }

    }
}