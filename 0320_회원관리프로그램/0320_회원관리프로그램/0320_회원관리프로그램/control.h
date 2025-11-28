//control.h
#pragma once

void con_Init(HWND hDlg);

void con_FileSave(HWND hDlg);
void con_FileLoad(HWND hDlg);

void con_InsertMember(HWND hDlg);

void con_LogIn(HWND hDlg);
Member* CheckLogIn(HWND hDlg, TCHAR* id, TCHAR* pw);

void con_SelectMember(HWND hDlg);
Member* SelectMember(HWND hDlg, TCHAR* id);

void con_UpdateMember(HWND hDlg);

void con_DeleteMember(HWND hDlg);
int SelectMemberIdx(HWND hDlg, TCHAR* id);