import pypyjit
pypyjit.set_param('max_unroll_recursion=-1')

def main():
    S = input().strip()
    ans = 0
    for c in 'ABCDEFGHIJKLMNOPQRSTUVWXYZ':
        pos_c = [i+1 for i, ch in enumerate(S) if ch == c]
        m = len(pos_c)
        if m < 2:
            continue
        cum_pos = 0
        for k in range(m):
            pos_k = pos_c[k]
            ans += (pos_k - 1) * k - cum_pos
            cum_pos += pos_k
    print(ans)

if __name__ == "__main__":
    main()
