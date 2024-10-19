import sys

def min_cost(w, main_a, main_p, sub_a, sub_p):
    cost = float('inf')
    for t in range(main_a):
        s = (max(0, w - sub_a * t) + main_a - 1) // main_a
        cost = min(cost, main_p * s + sub_p * t)
    return cost

def is_ok(w):
    cost = 0
    for a, p, b, q in ST:
        cost += min(min_cost(w, a, p, b, q), min_cost(w, b, q, a, p))
        if X < cost:
            return False
    return True

def main():
    input = sys.stdin.read
    data = input().split()
    
    global INF
    INF = 10**18
    global N, X, ST
    N, X = int(data[0]), int(data[1])
    ST = [tuple(map(int, data[i:i+4])) for i in range(2, 2 + 4 * N, 4)]
    
    ok, ng = 0, X * 100 + 1
    while ng - ok > 1:
        m = (ng + ok) // 2
        if is_ok(m):
            ok = m
        else:
            ng = m
    print(ok)

if __name__ == "__main__":
    main()
