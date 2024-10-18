def main():
    import sys
    input = sys.stdin.readline

    N = int(input())
    grid = [list(sys.stdin.readline().strip()) for _ in range(N)]
    result = [[''] * N for _ in range(N)]

    N_minus_1 = N - 1
    half_N = N // 2

    for x in range(N):
        for y in range(N):
            # レイヤー番号の計算（0-based）
            layer = min(x, y, N_minus_1 - x, N_minus_1 - y)
            # このセルに適用される操作回数
            s = half_N - layer
            # 操作の周期性を考慮
            k = s % 4

            # 操作の座標変換を適用
            x0, y0 = x, y
            if k == 0:
                pass  # 変化なし
            elif k == 1:
                x0, y0 = y, N_minus_1 - x
            elif k == 2:
                x0, y0 = N_minus_1 - x, N_minus_1 - y
            elif k == 3:
                x0, y0 = N_minus_1 - y, x

            result[x][y] = grid[x0][y0]

    for row in result:
        print(''.join(row))

if __name__ == "__main__":
    main()
