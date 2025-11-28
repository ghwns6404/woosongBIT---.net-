//control.cpp
#include "std.h"

vector<Member*> g_members;

void con_Init(HWND hDlg)
{
	ui_InitControl(hDlg);
}

void con_FileSave(HWND hDlg)
{
	try
	{
		file_SaveMember(g_members);
	}
	catch (const TCHAR* msg)
	{
		MessageBox(hDlg, msg, TEXT("file save"), MB_OK);
	}
}

void con_FileLoad(HWND hDlg)
{
	try
	{
		file_LoadMember(g_members);
		ui_MemberPrint(hDlg, g_members);
	}
	catch (const TCHAR* msg)
	{
		MessageBox(hDlg, msg, TEXT("file load"), MB_OK);
	}
}

/*
1. [ui]회원정보 획득
2. [member]회원정보 -> Member객체를 생성
3. [control]Member객체 -> g_members에 저장
4. [control]성공 실패 출력
*/
void con_InsertMember(HWND hDlg)
{
	TCHAR id[20], pw[20], name[20], phone[20];
	int age;

	try
	{
		ui_GetInsertData(hDlg, id, _countof(id), pw, _countof(pw), name, _countof(name), phone, _countof(phone), &age);
		Member* pmember = member_CreateMember(id, pw, name, phone, age);
		g_members.push_back(pmember);
		//MessageBox(hDlg, TEXT("회원가입 성공"), TEXT("insert"), MB_OK);
		ui_MemberPrint(hDlg, g_members);
	}
	catch (const TCHAR* msg)
	{
		MessageBox(hDlg, msg, TEXT("insert"), MB_OK);
	}
}

/*
1. [ui]로그인정보 획득
2. [control]로그인 정보 일치 여부 확인 --> 별도 함수로 처리
3. [control]성공 실패 출력
*/
void con_LogIn(HWND hDlg)
{
	TCHAR id[20], pw[20];

	try
	{
		ui_GetLogInData(hDlg, id, _countof(id), pw, _countof(pw));
		CheckLogIn(hDlg, id, pw);
		MessageBox(hDlg, TEXT("로그인 성공"), TEXT("login"), MB_OK);
	}
	catch (const TCHAR* msg)
	{
		MessageBox(hDlg, msg, TEXT("login"), MB_OK);
	}
}
Member* CheckLogIn(HWND hDlg, TCHAR* id, TCHAR* pw)
{
	for (int i = 0; i < g_members.size(); i++)
	{
		Member* pmember = g_members[i];
		if (_tcscmp(pmember->id, id) == 0 && _tcscmp(pmember->pw, pw) == 0)
			return pmember;
	}
	throw TEXT("아이디, 패스워드가 일치하지 않습니다");
}

/*
1. [ui]검색정보 획득
2. [control] 검색(id) -> Member* --> 별도 함수로 처리
3. [control] 3.1 실패 메시지 출력
             3.2 [ui]성공시 검색 결과 출력
*/
void con_SelectMember(HWND hDlg)
{
	TCHAR id[20];

	try
	{
		ui_GetSelectData(hDlg, id, _countof(id));
		Member* pmember = SelectMember(hDlg, id);	
		ui_SetSelectMember(hDlg, pmember);
	}
	catch (const TCHAR* msg)
	{
		MessageBox(hDlg, msg, TEXT("select"), MB_OK);
	}
}
Member* SelectMember(HWND hDlg, TCHAR* id)
{
	for (int i = 0; i < g_members.size(); i++)
	{
		Member* pmember = g_members[i];
		if (_tcscmp(pmember->id, id) == 0 )
			return pmember;
	}
	throw TEXT("없는 아이디 입니다.");
}

/*
1. [ui]수정할 정보(id, phone, age) 획득
2. [control] 검색(id) -> Member* --> 별도 함수로 처리
3. [control] 3.1 실패 메시지 출력
			 3.2 [member] Member*값을 변경
*/
void con_UpdateMember(HWND hDlg)
{
	TCHAR id[20], phone[20];
	int age;

	try
	{
		ui_GetUpdateData(hDlg, id, _countof(id), phone, _countof(phone), &age);
		Member* pmember = SelectMember(hDlg, id);
		member_setData(pmember, phone, age);
		ui_MemberPrint(hDlg, g_members);
	}
	catch (const TCHAR* msg)
	{
		MessageBox(hDlg, msg, TEXT("update"), MB_OK);
	}
}

/*
1. [ui]삭제할 정보(id) 획득
2. [control] 검색(id) -> idx --> 별도 함수로 처리
3. [control] 3.1 실패 메시지 출력
			 3.2 해당 정보 삭제
*/
void con_DeleteMember(HWND hDlg)
{
	TCHAR id[20];

	try
	{
		ui_GetSelectData(hDlg, id, _countof(id));
		int idx = SelectMemberIdx(hDlg, id);
		g_members.erase(g_members.begin() + idx);
		//MessageBox(hDlg, TEXT("회원삭제 성공"), TEXT("delete"), MB_OK);
		ui_MemberPrint(hDlg, g_members);
	}
	catch (const TCHAR* msg)
	{
		MessageBox(hDlg, msg, TEXT("delete"), MB_OK);
	}
}
int SelectMemberIdx(HWND hDlg, TCHAR* id)
{
	for (int i = 0; i < g_members.size(); i++)
	{
		Member* pmember = g_members[i];
		if (_tcscmp(pmember->id, id) == 0)
			return i;
	}
	throw TEXT("없는 아이디 입니다.");
}