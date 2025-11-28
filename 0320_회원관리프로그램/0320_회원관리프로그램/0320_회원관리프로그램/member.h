//member.h
#pragma once

typedef struct tagMember
{
	TCHAR id[20];
	TCHAR pw[20];
	TCHAR name[20];
	int age;
	TCHAR phone[20];
}Member;

Member* member_CreateMember(TCHAR* id, TCHAR* pw, TCHAR* name, TCHAR* phone, int age);

void member_setData(Member* pmember, TCHAR* phone, int age);