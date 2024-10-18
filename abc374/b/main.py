import sys

def main():
    input = sys.stdin.read
    data = input().split()
    S = data[0].strip()
    T = data[1].strip()
    
    min_length = min(len(S), len(T))
    
    for i in range(min_length):
        if S[i] != T[i]:
            print(i + 1)
            return
    
    if len(S) != len(T):
        print(min_length + 1)
    else:
        print(0)

if __name__ == "__main__":
    main()
