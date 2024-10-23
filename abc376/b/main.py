import sys

def main():
    import sys
    N_Q = sys.stdin.readline().split()
    N = int(N_Q[0])
    Q = int(N_Q[1])
    instructions = []
    for _ in range(Q):
        parts = sys.stdin.readline().split()
        H = parts[0]
        T = int(parts[1])
        instructions.append((H, T))
    left = 1
    right = 2
    total_steps = 0
    for H, T in instructions:
        if H == 'L':
            S = left
            O = right
        else:
            S = right
            O = left
        T_i = T
        d_clockwise = (T_i - S + N) % N
        d_to_O_clockwise = (O - S + N) % N
        if 0 < d_to_O_clockwise < d_clockwise:
            steps = (S - T_i + N) % N
        else:
            steps = d_clockwise
        total_steps += steps
        if H == 'L':
            left = T_i
        else:
            right = T_i
    print(total_steps)

if __name__ == "__main__":
    main()
