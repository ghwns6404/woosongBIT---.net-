//control.cpp
#include "std.h"

//설정 정보의 용도 
SHAPE g_shape;

//도형 저장 정보
vector<SHAPE> g_shapes;

void con_ShapeInsert(HWND hwnd, POINTS pt)
{
	//구조체 변수 간 대입연산 가능!!!
	SHAPE newshape = g_shape;
	g_shapes.push_back(newshape);

	InvalidateRect(hwnd, 0, TRUE);
}

void con_ShapeDelete(HWND hwnd)
{
	if (g_shapes.size() == 0)
	{
		MessageBox(hwnd, TEXT("없다"), TEXT("삭제"), MB_OK);
		return;
	}
	g_shapes.erase(g_shapes.begin() + g_shapes.size()-1);
	InvalidateRect(hwnd, 0, TRUE);
}


void con_init(HWND hwnd)
{
	POINTS pt = { 200, 100 };
	shape_SetData(&g_shape, 2, RGB(255, 0, 0), RGB(0, 255, 0), pt, 75);
}

void con_Print(HWND hwnd, HDC hdc)
{
	//print_ShapePrint(hwnd, hdc, &g_shape);
	for (int i = 0; i < g_shapes.size(); i++)
	{
		SHAPE sh = g_shapes[i];
		print_ShapePrint(hwnd, hdc, &sh);
	}
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