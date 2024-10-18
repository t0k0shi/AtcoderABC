import sys
import itertools
import math

def distance(x1, y1, x2, y2):
    return math.sqrt((x2 - x1)**2 + (y2 - y1)**2)

def calculate_time(N, S, T, segments):
    min_time = float('inf')

    # Generate all permutations of the segments
    for perm in itertools.permutations(segments):
        # For each permutation, consider both directions for each segment
        for start_directions in itertools.product([0, 1], repeat=N):
            current_time = 0
            current_position = (0, 0)

            for i, segment in enumerate(perm):
                (Ax, Ay), (Bx, By) = segment
                if start_directions[i] == 0:
                    # Start from (Ax, Ay) and move to (Bx, By)
                    start = (Ax, Ay)
                    end = (Bx, By)
                else:
                    # Start from (Bx, By) and move to (Ax, Ay)
                    start = (Bx, By)
                    end = (Ax, Ay)

                # Move to the start of the segment
                current_time += distance(current_position[0], current_position[1], start[0], start[1]) / S
                # Print while moving along the segment
                current_time += distance(start[0], start[1], end[0], end[1]) / T
                current_position = end

            min_time = min(min_time, current_time)

    return min_time

def main():
    input = sys.stdin.read
    data = input().split()
    
    N = int(data[0])
    S = int(data[1])
    T = int(data[2])
    
    segments = []
    index = 3
    for _ in range(N):
        Ax = int(data[index])
        Ay = int(data[index + 1])
        Bx = int(data[index + 2])
        By = int(data[index + 3])
        segments.append(((Ax, Ay), (Bx, By)))
        index += 4
    
    min_time = calculate_time(N, S, T, segments)
    
    # Print the result with exactly 20 decimal places
    print(f"{min_time:.20f}")

if __name__ == "__main__":
    main()
