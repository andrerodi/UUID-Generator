using System.Linq;

namespace UUID_Generator
{
    [Command(PackageIds.InsertGuid)]
    internal sealed class InsertGuid : BaseCommand<InsertGuid>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync();

            var selection = docView?.TextView.Selection.SelectedSpans.FirstOrDefault();

            if (selection is null)
            {
                return;
            }

            var uuid = Guid.NewGuid().ToString();

            docView.TextBuffer.Replace(selection.Value, uuid);
        }
    }
}
