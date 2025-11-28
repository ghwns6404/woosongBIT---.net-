//handler.cpp
#include "std.h"

INT_PTR OnInitDialog(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	con_Init(hDlg);
	return TRUE;
}

INT_PTR OnCommand(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	if (LOWORD(wParam) == IDCANCEL)
	{
		EndDialog(hDlg, IDCANCEL);
		return TRUE;
	}
	else if (LOWORD(wParam) == IDC_BUTTON1)
	{
		con_InsertMember(hDlg);
		return TRUE;
	}
	else if (LOWORD(wParam) == IDC_BUTTON2)
	{
		con_LogIn(hDlg);
		return TRUE;
	}
	else if (LOWORD(wParam) == IDC_BUTTON3)
	{
		con_SelectMember(hDlg);
		return TRUE;
	}
	else if (LOWORD(wParam) == IDC_BUTTON4)
	{
		con_UpdateMember(hDlg);
		return TRUE;
	}
	else if (LOWORD(wParam) == IDC_BUTTON5)
	{
		con_DeleteMember(hDlg);
		return TRUE;
	}
	else if (LOWORD(wParam) == IDC_BUTTON6)
	{
		con_FileSave(hDlg);
		return TRUE;
	}
	else if (LOWORD(wParam) == IDC_BUTTON7)
	{
		con_FileLoad(hDlg);
		return TRUE;
	}
	return FALSE;
}
