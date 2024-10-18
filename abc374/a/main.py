import sys

def main():
    input = sys.stdin.read
    S = input().strip()
    
    if S.endswith("san"):
        print("Yes")
    else:
        print("No")

if __name__ == "__main__":
    main()
