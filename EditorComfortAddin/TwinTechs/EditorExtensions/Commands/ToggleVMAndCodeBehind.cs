using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using TwinTechs.EditorExtensions.Helpers;

namespace TwinTechs.EditorExtensions.Commands
{

	public class ToggleVMAndCodeBehind : CommandHandler
	{
		protected override void Run ()
		{
			ViewModelHelper.Instance.ToggleVMAndCodeBehind ();
		}

		protected override void Update (CommandInfo info)
		{
			var isEnabled = IdeApp.Workspace.GetIsWorkspaceOpen () && IdeApp.Workspace.GetIsDocumentOpen ()
			                && ViewModelHelper.Instance.IsActiveFileAViewFile
			                && ViewModelHelper.Instance.IsTogglingPossibleForActiveDocument;

			//TODO check if document is xaml/codebehind/vm
			info.Enabled = isEnabled;

			info.Visible = true;
		}
	}

}
