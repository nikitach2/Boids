#define MAX 1000000000
int state[55];
int si = 0;
int sj = 0;
int i = 0;
int j = 0;
int x = 0;
int p2 = 1;

int Subgen_Next();
void Subgen_Init(int seed)
{
	state[0] = seed % MAX;
	for (i = 1, j = 21; i < 55; i++, j += 21)
    {
		if (j >= 55) j -= 55;
		state[j] = p2;
        p2 = seed - p2;
		if (p2 < 0) p2 += MAX;
		seed = state[j];
	}
	si = 0;
	sj = 24;

	for (i = 0; i < 165; i++) Subgen_Next();
}
int Subgen_Next()
{
	if (si == sj) Subgen_Init(0);
	if (!si--) si = 54;
	if (!sj--) sj = 54;
    x = state[si] - state[sj];
	if (x < 0) x += MAX;
    // printf("%i\n",x);
	return state[si] = x;
}
float Subgen_FractionUnsigned()
{
	int next = Subgen_Next();
	// printf("%i\n",next);
    return next / (float)MAX;
}
float Subgen_FractionSigned()
{
	float result = Subgen_FractionUnsigned() * 2 - 1;
	// printf("%X", *(unsigned int *)&result);
	// printf("\n");
    return result;
}
float Subgen_Range(float min, float max)
{
	float result = min + ((max - min) * Subgen_FractionUnsigned());
	// printf("%X", *(unsigned int *)&result);
	// printf("\n");
    return result;
}