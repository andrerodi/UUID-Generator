using System.Linq;

namespace UUID_Generator.Commands
{
    [Command(PackageIds.InsertUlid)]
    internal sealed class InsertUlid : BaseCommand<InsertUlid>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync();

            var selection = docView?.TextView.Selection.SelectedSpans.FirstOrDefault();

            if (selection is null)
            {
                return;
            }

            var uuid = Ulid.NewUlid().ToGuid().ToString();

            docView.TextBuffer.Replace(selection.Value, uuid);
        }
    }
}
