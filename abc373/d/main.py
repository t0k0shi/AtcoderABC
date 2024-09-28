import pypyjit
pypyjit.set_param('max_unroll_recursion=-1')
import sys
from sys import stdin
import sys
sys.setrecursionlimit(1 << 25)

class UnionFind:
    def __init__(self, size):
        self.parent = list(range(size))
        self.rank = [0] * size
        self.potential = [0] * size  # potential[x] = x_i - x_parent[x]

    def find(self, x):
        if self.parent[x] != x:
            orig_parent = self.parent[x]
            self.parent[x] = self.find(self.parent[x])
            self.potential[x] += self.potential[orig_parent]
        return self.parent[x]

    def union(self, x, y, w):
        # x + w = y  => x_i + w = y_i
        root_x = self.find(x)
        root_y = self.find(y)
        if root_x == root_y:
            if self.potential[y] - self.potential[x] != w:
                # Contradiction, but problem guarantees no contradictions
                pass
            return
        # Union by rank
        if self.rank[root_x] < self.rank[root_y]:
            self.parent[root_x] = root_y
            self.potential[root_x] = self.potential[y] - self.potential[x] - w
        else:
            self.parent[root_y] = root_x
            self.potential[root_y] = self.potential[x] + w - self.potential[y]
            if self.rank[root_x] == self.rank[root_y]:
                self.rank[root_x] += 1

def solve():
    import sys
    from sys import stdin
    input = sys.stdin.read().split()
    idx = 0
    N = int(input[idx]); idx +=1
    M = int(input[idx]); idx +=1
    uf = UnionFind(N+1)
    for _ in range(M):
        u = int(input[idx]); idx +=1
        v = int(input[idx]); idx +=1
        w = int(input[idx]); idx +=1
        uf.union(u, v, w)
    x = [0] * (N+1)
    for i in range(1, N+1):
        uf.find(i)
        x[i] = uf.potential[i]
    print(' '.join(map(str, x[1:])))

if __name__ == "__main__":
    solve()
