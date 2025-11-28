//control.h
#pragma once

void con_init(HWND hwnd);
void con_Print(HWND hwnd, HDC hdc);
void con_UpdateShapePoint(HWND hwnd, POINTS pt);
void con_UpdateShapeSize(HWND hwnd, int key);
void con_UpdateShapeType(HWND hwnd, int key);
void con_UpdateShapeBrushColor(HWND hwnd, int key);

void con_ShapeInsert(HWND hwnd, POINTS pt);
void con_ShapeDelete(HWND hwnd);

