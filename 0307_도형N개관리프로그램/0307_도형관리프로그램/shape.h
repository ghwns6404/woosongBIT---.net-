//shape.h
#pragma once

typedef struct tagSHAPE
{
	int type;			//1 : 사각형   2 : 타원
	COLORREF br_color;	//브러쉬 색상
	COLORREF pen_color; //펜 색상
	POINTS pt;			//좌표
	int size;			//도형의 크기(25, 50, 75, 100)
}SHAPE, *PSHAPE;

void shape_SetData(SHAPE *pshape, int type, COLORREF br_color, COLORREF pen_color,POINTS pt, int size);

void shape_SetType(SHAPE* pshape, int type);
void shape_SetBrushColor(SHAPE* pshape, COLORREF br_color);
void shape_SetPenColor(SHAPE* pshape, COLORREF pen_color);
void shape_SetPoint(SHAPE* pshape, POINTS pt);
void shape_SetSize(SHAPE* pshape, int size);

int shape_GetType(const SHAPE* pshape);
COLORREF shape_GetBrushColor(const SHAPE* pshape);
COLORREF shape_GetPenColor(const SHAPE* pshape);
POINTS shape_GetPoint(const SHAPE* pshape);
int shape_GetSize(const SHAPE* pshape);

void shape_tostring(const SHAPE* pshape, TCHAR* buf);