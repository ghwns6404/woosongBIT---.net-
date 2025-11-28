//print.cpp
#include "std.h"

void print_ShapePrint(HWND hwnd, HDC hdc, const SHAPE* pshape)
{
	HBRUSH brush	= CreateSolidBrush(pshape->br_color);
	HBRUSH oldbrush = (HBRUSH)SelectObject(hdc, brush);

	HPEN pen		= CreatePen(PS_SOLID, 3, pshape->pen_color);
	HPEN oldpen		= (HPEN)SelectObject(hdc, pen);

	if (pshape->type == 1)
	{
		Rectangle(hdc, pshape->pt.x, pshape->pt.y,
			pshape->pt.x + pshape->size, pshape->pt.y + pshape->size);
	}
	else if (pshape->type == 2)
	{
		Ellipse(hdc, pshape->pt.x, pshape->pt.y,
			pshape->pt.x + pshape->size, pshape->pt.y + pshape->size);
	}

	DeleteObject(SelectObject(hdc, oldbrush));
	DeleteObject(SelectObject(hdc, oldpen));
}