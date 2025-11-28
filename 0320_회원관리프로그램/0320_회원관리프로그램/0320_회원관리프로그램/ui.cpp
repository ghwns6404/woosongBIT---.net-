//ui.cpp
#include "std.h"

HWND hList;

void ui_InitControl(HWND hDlg)
{
	hList = GetDlgItem(hDlg, IDC_LIST2);

	//리스트뷰에 헤더
	LVCOLUMN COL;

	COL.mask = LVCF_FMT | LVCF_WIDTH | LVCF_TEXT | LVCF_SUBITEM;
	COL.fmt = LVCFMT_LEFT;
	COL.cx = 150;


	COL.pszText = (LPTSTR)TEXT("아이디");
	COL.iSubItem = 0;
	SendMessage(hList, LVM_INSERTCOLUMN, 0, (LPARAM)&COL);

	COL.pszText = (LPTSTR)TEXT("패스워드");
	COL.iSubItem = 1;
	SendMessage(hList, LVM_INSERTCOLUMN, 1, (LPARAM)&COL);

	COL.pszText = (LPTSTR)TEXT("이름");
	COL.iSubItem = 2;
	SendMessage(hList, LVM_INSERTCOLUMN, 2, (LPARAM)&COL);

	COL.pszText = (LPTSTR)TEXT("나이");
	COL.iSubItem = 3;
	SendMessage(hList, LVM_INSERTCOLUMN, 3, (LPARAM)&COL);

	COL.pszText = (LPTSTR)TEXT("전화번호");
	COL.iSubItem = 4;
	SendMessage(hList, LVM_INSERTCOLUMN, 4, (LPARAM)&COL);

	ListView_SetExtendedListViewStyle(hList, LVS_EX_FULLROWSELECT |LVS_EX_GRIDLINES | LVS_EX_HEADERDRAGDROP);
	// LVS_EX_FULLROWSELECT |LVS_EX_GRIDLINES | LVS_EX_CHECKBOXES | LVS_EX_HEADERDRAGDROP);
}

void ui_MemberPrint(HWND hDlg, const vector<Member*>& members)
{
	SendMessage(hList, LVM_DELETEALLITEMS, 0, 0);

	for (int i = 0; i < members.size(); i++)
	{
		Member* pmember = members[i];
		
		LVITEM LI;
		LI.mask = LVIF_TEXT;
		LI.iSubItem = 0;
		LI.iItem	= 0;
		LI.pszText	= pmember->id;      
		SendMessage(hList, LVM_INSERTITEM, i, (LPARAM)&LI);

		LI.iSubItem = 1;
		LI.pszText = pmember->pw;
		SendMessage(hList, LVM_SETITEM, i, (LPARAM)&LI);

		LI.iSubItem = 2;
		LI.pszText = pmember->name;
		SendMessage(hList, LVM_SETITEM, i, (LPARAM)&LI);

		LI.iSubItem = 3;
		TCHAR buf[20];
		wsprintf(buf, TEXT("%d세"), pmember->age);
		LI.pszText = buf;
		SendMessage(hList, LVM_SETITEM, i, (LPARAM)&LI);

		LI.iSubItem = 4;
		LI.pszText = pmember->phone;
		SendMessage(hList, LVM_SETITEM, i, (LPARAM)&LI);
	}
}

void ui_GetInsertData(HWND hDlg, TCHAR* id, int id_size, TCHAR* pw, int pw_size, TCHAR* name, int name_size, TCHAR* phone, int phone_size, int* age)
{
	GetDlgItemText(hDlg, IDC_EDIT1, id, id_size);
	GetDlgItemText(hDlg, IDC_EDIT2, pw, pw_size);
	GetDlgItemText(hDlg, IDC_EDIT3, name, name_size);
	*age = GetDlgItemInt(hDlg, IDC_EDIT4, 0, 0);
	GetDlgItemText(hDlg, IDC_EDIT5, phone, phone_size);
}

void ui_GetLogInData(HWND hDlg, TCHAR* id, int id_size, TCHAR* pw, int pw_size)
{
	GetDlgItemText(hDlg, IDC_EDIT6, id, id_size);
	GetDlgItemText(hDlg, IDC_EDIT7, pw, pw_size);
}

void ui_GetSelectData(HWND hDlg, TCHAR* id, int id_size)
{
	GetDlgItemText(hDlg, IDC_EDIT8, id, id_size);
}

void ui_SetSelectMember(HWND hDlg, Member* pmember)
{
	//SetDlgItemText(hDlg, IDC_EDIT8, pmember->id);
	SetDlgItemText(hDlg, IDC_EDIT9, pmember->pw);
	SetDlgItemText(hDlg, IDC_EDIT10, pmember->name);
	SetDlgItemInt(hDlg, IDC_EDIT11, pmember->age, 0);
	SetDlgItemText(hDlg, IDC_EDIT12, pmember->phone);
}

void ui_GetUpdateData(HWND hDlg, TCHAR* id, int id_size, TCHAR* phone, int phone_size, int* age)
{
	GetDlgItemText(hDlg, IDC_EDIT8, id, id_size);
	*age = GetDlgItemInt(hDlg, IDC_EDIT11, 0, 0);
	GetDlgItemText(hDlg, IDC_EDIT12, phone, phone_size);
}