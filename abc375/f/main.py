import pypyjit
pypyjit.set_param('max_unroll_recursion=-1')
import sys
import heapq

def dijkstra(adj, start, n):
    dist = [float('inf')] * n 
    dist[start] = 0
    pq = [(0, start)]
    while pq:
        d, u = heapq.heappop(pq)
        if d > dist[u]:
            continue
        for v, cost in adj[u]:
            if dist[u] + cost < dist[v]:
                dist[v] = dist[u] + cost
                heapq.heappush(pq, (dist[v], v))
    return dist

def main():
    input = sys.stdin.read
    data = input().split()
    
    index = 0
    N = int(data[index])
    M = int(data[index + 1])
    Q = int(data[index + 2])
    index += 3
    
    adj = [[] for _ in range(N)]
    edges = []
    
    for _ in range(M):
        A = int(data[index]) - 1
        B = int(data[index + 1]) - 1
        C = int(data[index + 2])
        adj[A].append((B, C))
        adj[B].append((A, C))
        edges.append((A, B, C))
        index += 3
    
    closed = [False] * M
    results = []
    
    for _ in range(Q):
        query = data[index]
        if query == '1':
            i = int(data[index + 1]) - 1
            A, B, C = edges[i]
            adj[A].remove((B, C))
            adj[B].remove((A, C))
            closed[i] = True
            index += 2
        elif query == '2':
            x = int(data[index + 1]) - 1
            y = int(data[index + 2]) - 1
            dist = dijkstra(adj, x, N)
            results.append(-1 if dist[y] == float('inf') else dist[y])
            index += 3
    
    print("\n".join(map(str, results)))

if __name__ == "__main__":
    main()
