//control.cpp
#include "std.h"

SHAPE g_shape;

void con_init(HWND hwnd)
{
	POINTS pt = { 200, 100 };
	shape_SetData(&g_shape, 2, RGB(255, 0, 0), RGB(0, 255, 0), pt, 75);
}

void con_Print(HWND hwnd, HDC hdc)
{
	print_ShapePrint(hwnd, hdc, &g_shape);
}

void con_UpdateShapePoint(HWND hwnd, POINTS pt)
{
	shape_SetPoint(&g_shape, pt);

	InvalidateRect(hwnd, 0, TRUE);	
}

void con_UpdateShapeSize(HWND hwnd, int key)
{
	int size = g_shape.size;
	if (key == VK_UP)
	{
		if (size >= 100)
			size = 0;//return;
		size = size + 25;
	}
	else if (key == VK_DOWN)
	{
		if (size <= 25)
			size = 100;//return;
		size = size - 25;		
	}	
	else
	{
		return;
	}
	shape_SetSize(&g_shape, size);
	InvalidateRect(hwnd, 0, TRUE);
}

void con_UpdateShapeType(HWND hwnd, int key)
{
	if( key == '1' || key == VK_NUMPAD1)
		shape_SetType(&g_shape, 1);
	else if (key == '2' || key == VK_NUMPAD2)
		shape_SetType(&g_shape, 2);

	InvalidateRect(hwnd, 0, TRUE);
}

void con_UpdateShapeBrushColor(HWND hwnd, int key)
{
	if (key == 'R')
		shape_SetBrushColor(&g_shape, RGB(255, 0, 0));
	else if (key == 'G')
		shape_SetBrushColor(&g_shape, RGB(0, 255, 0));
	else if (key == 'B')
		shape_SetBrushColor(&g_shape, RGB(0, 0, 255));

	InvalidateRect(hwnd, 0, TRUE);
}