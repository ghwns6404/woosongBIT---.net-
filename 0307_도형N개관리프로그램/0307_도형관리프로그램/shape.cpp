//shape.cpp

#include "std.h"

void shape_SetData(SHAPE* pshape, int type, COLORREF br_color, COLORREF pen_color, POINTS pt, int size)
{
	pshape->type		= type;
	pshape->br_color	= br_color;
	pshape->pen_color	= pen_color;
	pshape->pt			= pt;
	pshape->size		= size;
}

void shape_SetType(SHAPE* pshape, int type)
{
	pshape->type = type;
}

void shape_SetBrushColor(SHAPE* pshape, COLORREF br_color)
{
	pshape->br_color = br_color;
}

void shape_SetPenColor(SHAPE* pshape, COLORREF pen_color)
{
	pshape->pen_color = pen_color;
}

void shape_SetPoint(SHAPE* pshape, POINTS pt)
{
	pshape->pt = pt;
}

void shape_SetSize(SHAPE* pshape, int size)
{
	pshape->size = size;
}

int shape_GetType(const SHAPE* pshape)
{
	return pshape->type;
}

COLORREF shape_GetBrushColor(const SHAPE* pshape)
{
	return pshape->br_color;
}

COLORREF shape_GetPenColor(const SHAPE* pshape)
{
	return pshape->pen_color;
}

POINTS shape_GetPoint(const SHAPE* pshape)
{
	return pshape->pt;
}

int shape_GetSize(const SHAPE* pshape)
{
	return pshape->size;
}

void shape_tostring(const SHAPE* pshape, TCHAR* buf)
{
	wsprintf(buf, TEXT("%d \r\n %s \r\n %s \r\n (%d, %d) \r\n %d"),
		pshape->type, pshape->pen_color, pshape->br_color,
		pshape->pt.x, pshape->pt.y, pshape->size);
}