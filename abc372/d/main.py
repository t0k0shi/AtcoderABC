import sys

def main():
    import sys
    sys.setrecursionlimit(1 << 25)
    input = sys.stdin.read
    data = input().split()
    
    # 入力の取得
    idx = 0
    N = int(data[idx])
    idx +=1
    H = list(map(int, data[idx:idx+N]))
    idx +=N
    
    # prev_greater[j]: ビルjより左で最も右側にあり、H_i > H_j
    prev_greater = [-1]*N
    stack = []
    for j in range(N):
        while stack and H[stack[-1]] < H[j]:
            stack.pop()
        if stack:
            prev_greater[j] = stack[-1]
        else:
            prev_greater[j] = -1
        stack.append(j)
    
    # 差分配列を用いてc_iを計算
    c_diff = [0]*(N+1)  # N+1で十分
    for j in range(N):
        left = prev_greater[j] if prev_greater[j] != -1 else 0
        right = j -1
        if left <= right:
            c_diff[left] +=1
            c_diff[j] -=1
    
    # 累積和を計算してc_iを求める
    result = []
    current =0
    for i in range(N):
        current += c_diff[i]
        result.append(current)
    
    # 出力
    print(' '.join(map(str, result)))

if __name__ == "__main__":
    main()
