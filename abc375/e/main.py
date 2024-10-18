def main():
    import sys
    import threading
    def solve():
        N = int(sys.stdin.readline())
        A = []
        B = []
        total_strength = 0
        for _ in range(N):
            a, b = map(int, sys.stdin.readline().split())
            A.append(a)
            B.append(b)
            total_strength += b

        if total_strength % 3 != 0:
            print(-1)
            return

        T = total_strength // 3  # Target strength per team

        # Calculate the initial team strengths
        team_strength = [0, 0, 0, 0]  # Index 1-based
        for i in range(N):
            team_strength[A[i]] += B[i]

        # Calculate the surplus or deficit of each team
        over = [0, team_strength[1] - T, team_strength[2] - T, team_strength[3] - T]

        # Check if it's possible to balance the strengths
        if over[1] % 1 != 0 or over[2] % 1 != 0 or over[3] % 1 != 0:
            print(-1)
            return

        # If all over values are zero, no need to change teams
        if over[1] == 0 and over[2] == 0 and over[3] == 0:
            print(0)
            return

        # Build the flow network
        # Nodes:
        # 0: Source
        # 1-3: Teams 1-3
        # 4-N+3: People 1 to N
        # N+4: Sink
        from collections import deque

        INF = float('inf')
        num_nodes = N + 5  # Nodes are from 0 to N+4
        edges = [[] for _ in range(num_nodes)]

        # Function to add edges to the network
        def add_edge(u, v, cap, cost):
            edges[u].append([v, cap, cost, len(edges[v])])
            edges[v].append([u, 0, -cost, len(edges[u]) - 1])

        S = 0  # Source
        T_node = N + 4  # Sink

        # Total surplus and deficits
        total_surplus = 0
        for t in range(1, 4):
            if over[t] > 0:
                # Surplus team: connect to source
                add_edge(S, t, over[t], 0)
                total_surplus += over[t]
            elif over[t] < 0:
                # Deficit team: connect to sink
                add_edge(t, T_node, -over[t], 0)

        # Connect teams to people
        for i in range(N):
            person_node = i + 4
            team = A[i]
            strength = B[i]

            # From team to person
            add_edge(team, person_node, strength, 0)

            # From person to other teams (not their current team)
            for t in range(1, 4):
                if t != team:
                    add_edge(person_node, t, strength, 1)  # Cost 1 to change team

        # Min-Cost Max-Flow using Bellman-Ford algorithm
        result = 0  # Total cost
        flow = 0  # Total flow

        while True:
            dist = [INF] * num_nodes
            prev_node = [None] * num_nodes
            prev_edge = [None] * num_nodes
            in_queue = [False] * num_nodes
            dist[S] = 0
            queue = deque([S])

            while queue:
                u = queue.popleft()
                in_queue[u] = False
                for i in range(len(edges[u])):
                    v, cap, cost, rev = edges[u][i]
                    if cap > 0 and dist[v] > dist[u] + cost:
                        dist[v] = dist[u] + cost
                        prev_node[v] = u
                        prev_edge[v] = i
                        if not in_queue[v]:
                            queue.append(v)
                            in_queue[v] = True

            if dist[T_node] == INF:
                break  # No more augmenting path

            # Find the minimum capacity along the path
            d = INF
            v = T_node
            while v != S:
                u = prev_node[v]
                i = prev_edge[v]
                cap = edges[u][i][1]
                d = min(d, cap)
                v = u

            # Apply the flow
            v = T_node
            while v != S:
                u = prev_node[v]
                i = prev_edge[v]
                edges[u][i][1] -= d
                rev = edges[u][i][3]
                edges[v][rev][1] += d
                v = u

            flow += d
            result += dist[T_node] * d

        if flow < total_surplus:
            print(-1)
        else:
            print(int(result))

    threading.Thread(target=solve).start()
