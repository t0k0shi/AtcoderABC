import sys

def main():
    input = sys.stdin.read
    data = input().split()
    
    N = int(data[0])
    C = int(data[1])
    T = [int(data[i]) for i in range(2, N + 2)]
    
    candy_count = 0
    last_time = -C  # Initialize with a value to ensure first candy is always collected
    
    for time in T:
        if time - last_time >= C:
            candy_count += 1
            last_time = time

    print(candy_count)

if __name__ == "__main__":
    main()
