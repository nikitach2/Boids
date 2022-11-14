#include <stdlib.h>
#include <raylib.h>
#include <raymath.h>
#define _USE_MATH_DEFINES
#include <math.h>
#include <stdlib.h>
#include "subgen.h"
#include "string.h"

Vector2 Helper_Add(Vector2 v1, Vector2 v2)  { return (Vector2) { v1.x + v2.x , v1.y + v2.y }; }
Vector2 Helper_Sub(Vector2 v1, Vector2 v2)  { return (Vector2) { v1.x - v2.x , v1.y - v2.y }; }
Vector2 Helper_Mul(Vector2 v1, float value) { return (Vector2) { v1.x * value, v1.y * value }; }
Vector2 Helper_Div(Vector2 v1, float value) { return (Vector2) { v1.x / value, v1.y / value }; }
Vector2 Helper_Abs(Vector2 v1)              { return (Vector2) { fabs(v1.x), fabs(v1.y) }; }
bool    Helper_IsZero(Vector2 v1)           { return v1.x == 0 && v1.y == 0; }

void Helper_PrintEmptyLine() { printf("\n"); }
void Helper_PrintFloatHex(float f)
{
    unsigned int ui;
    memcpy(&ui, &f, sizeof (ui));
    printf("%X", ui);
    // printf("%X", *(unsigned int *)&f);
}
void Helper_PrintVector2(Vector2 v1) { printf("<%f,%f>\n",v1.x,v1.y); }
void Helper_PrintVector2Hex(Vector2 v1) { Helper_PrintFloatHex(v1.x), Helper_PrintFloatHex(v1.y); }
Vector2 Helper_RandNormDir()
{
    float x = Subgen_FractionSigned();
    float y = Subgen_FractionSigned();
    Vector2 result = Vector2Normalize( (Vector2) { x,y } );
    return result;
}