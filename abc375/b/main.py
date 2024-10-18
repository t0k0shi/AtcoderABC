import pypyjit
pypyjit.set_param('max_unroll_recursion=-1')
import sys
import math

def main():
    input = sys.stdin.read
    data = input().split()

    N = int(data[0])
    points = [(int(data[2 * i + 1]), int(data[2 * i + 2])) for i in range(N)]

    def distance(p1, p2):
        return math.sqrt((p1[0] - p2[0]) ** 2 + (p1[1] - p2[1]) ** 2)

    total_cost = 0

    # 原点から最初の点への距離を計算
    total_cost += distance((0, 0), points[0])

    # 各点間の距離を計算
    for i in range(1, N):
        total_cost += distance(points[i-1], points[i])

    # 最後の点から原点への距離を計算
    total_cost += distance(points[-1], (0, 0))

    print(f"{total_cost:.20f}")

if __name__ == "__main__":
    main()
