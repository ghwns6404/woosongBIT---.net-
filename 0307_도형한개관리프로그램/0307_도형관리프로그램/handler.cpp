//handler.cpp
#include  "std.h"

LRESULT OnCreate(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	//MessageBox(hwnd, TEXT("create"), TEXT("정보"), MB_OK);
	con_init(hwnd);

	return 0;
}

LRESULT OnDestroy(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	//MessageBox(hwnd, TEXT("destroy"), TEXT("정보"), MB_OK);

	PostQuitMessage(0);

	return 0;
}

LRESULT OnPaint(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT ps;
	HDC hdc = BeginPaint(hwnd, &ps);

	con_Print(hwnd, hdc);

	EndPaint(hwnd, &ps);
	return 0;
}

LRESULT OnLButtonDown(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	POINTS pt = MAKEPOINTS(lParam);

	con_UpdateShapePoint(hwnd, pt);

	return 0;
}

LRESULT OnKeyDown(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	int key = (int)wParam;

	if (key == VK_UP || key == VK_DOWN)
		con_UpdateShapeSize(hwnd, key);
	else if (key == '1' || key == '2' || key == VK_NUMPAD1 || key == VK_NUMPAD2)
		con_UpdateShapeType(hwnd, key);
	else if (key == 'R' || key == 'G' || key == 'B')
		con_UpdateShapeBrushColor(hwnd, key);

	return 0;
}