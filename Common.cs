/************************************************************************/
/* 功能：将菜单栏内容添加到treeview控件中显示，内部调用了下面GetCavernMenu函数
 * 参数：treeview 要添加到的地方
 *       MenuStrip 添加的源
 */
/************************************************************************/
private void GetMenu(TreeView treeV,MenuStrip Menus)
{
	for (int i = 0; i < Menus.Items.Count;i++ )
	{
		//将一级菜单项名称-->treeview的节点中
		TreeNode newNode1 = treeV.Nodes.Add(Menus.Items[i].Text);
		ToolStripDropDownItem newmenu = (ToolStripDropDownItem)Menus.Items[i];
		//调用下面的递归函数
		GetCavernMenu(newNode1, newmenu);
	}
	
}
/************************************************************************/
/*功能：递归添加菜单项到treeview中，在GetMenu函数中被调用
 *参数： newNodeA  上级的节点
 *       newMenuA 上级菜单
 */
/************************************************************************/
private void GetCavernMenu(TreeNode newNodeA, ToolStripDropDownItem newmenuA)
{
	//判断上一级菜单是否还有子项
	if (newmenuA.HasDropDownItems && newmenuA.DropDownItems.Count > 0)
	{
		for (int j = 0; j < newmenuA.DropDownItems.Count; j++)
		{
			//将子项添加到新的newnodeB节点中
			TreeNode newNodeB = newNodeA.Nodes.Add(newmenuA.DropDownItems[j].Text);
			//将子项菜单项转为ToolStripDropDownItem以便判断有无子项
			ToolStripDropDownItem newmenuB = (ToolStripDropDownItem)newmenuA.DropDownItems[j];
			
			//如果还有下一级递归调用
			if (newmenuB.HasDropDownItems && newmenuB.DropDownItems.Count > 0)
			{
				GetCavernMenu(newNodeB, newmenuB);
			}
		}
	}
}