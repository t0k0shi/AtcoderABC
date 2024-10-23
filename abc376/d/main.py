import sys
from collections import deque

def main():
    input = sys.stdin.read
    data = input().split()
    N = int(data[0])
    M = int(data[1])
    adj = [[] for _ in range(N+1)]
    to1 = []
    index = 2
    for _ in range(M):
        a = int(data[index])
        b = int(data[index+1])
        adj[a].append(b)
        if b == 1:
            to1.append(a)
        index += 2
    distance = [-1]*(N+1)
    distance[1] = 0
    q = deque([1])
    while q:
        u = q.popleft()
        for v in adj[u]:
            if distance[v] == -1:
                distance[v] = distance[u] +1
                q.append(v)
    min_cycle = float('inf')
    for u in to1:
        if distance[u] != -1:
            min_cycle = min(min_cycle, distance[u] +1)
    print(min_cycle if min_cycle != float('inf') else -1)

if __name__ == "__main__":
    main()
