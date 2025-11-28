//member.cpp
#include "std.h"

Member* member_CreateMember(TCHAR* id, TCHAR* pw, TCHAR* name, TCHAR* phone, int age)
{
	Member* pmember = (Member*)malloc(sizeof(Member));
	if (pmember == NULL)
		throw TEXT("메모리 생성 오류");

	_tcscpy_s(pmember->id, _countof(pmember->id), id);
	_tcscpy_s(pmember->pw, _countof(pmember->pw), pw);
	_tcscpy_s(pmember->name, _countof(pmember->name), name);
	_tcscpy_s(pmember->phone, _countof(pmember->phone), phone);
	pmember->age = age;

	return pmember; 
}

void member_setData(Member* pmember, TCHAR* phone, int age)
{
	_tcscpy_s(pmember->phone, _countof(pmember->phone), phone);
	pmember->age = age;
}