//ui.h
#pragma once

void ui_InitControl(HWND hDlg);
void ui_MemberPrint(HWND hDlg, const vector<Member*>& members);

void ui_GetInsertData(HWND hDlg, TCHAR* id, int id_size, TCHAR* pw, int pw_size, TCHAR* name, int name_size, TCHAR* phone, int phone_size, int* age);

void ui_GetLogInData(HWND hDlg, TCHAR* id, int id_size, TCHAR* pw, int pw_size);

void ui_GetSelectData(HWND hDlg, TCHAR* id, int id_size);
void ui_SetSelectMember(HWND hDlg, Member* pmember);

void ui_GetUpdateData(HWND hDlg, TCHAR* id, int id_size, TCHAR* phone, int phone_size, int* age);

