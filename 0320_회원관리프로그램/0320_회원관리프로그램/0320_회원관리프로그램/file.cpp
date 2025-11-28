//file.cpp
#include "std.h"

void file_SaveMember(const vector<Member*>& members)
{
	FILE* fp;
	int ret = fopen_s(&fp, "members.txt", "wb");
	if (ret != 0)
		throw TEXT("파일 저장 실패");

	int size = (int)members.size();
	fwrite(&size, sizeof(int), 1, fp);

	for (int i = 0; i < members.size(); i++)
	{
		Member* pmember = members[i];
		fwrite(pmember, sizeof(Member), 1, fp);
	}

	fclose(fp);
}

void file_LoadMember(vector<Member*>& members)
{
	members.clear();

	FILE* fp;
	int ret = fopen_s(&fp, "members.txt", "rb");
	if (ret != 0)
		throw TEXT("파일 열기 실패");

	int size;
    fread(&size, sizeof(int), 1, fp);

	for (int i = 0; i < size; i++)
	{
		Member* pmember = (Member*)malloc(sizeof(Member));
		fread(pmember, sizeof(Member), 1, fp);
		members.push_back(pmember);
	}

	fclose(fp);
}