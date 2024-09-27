# 入力の読み込み
import sys
input = sys.stdin.read
data = input().split()

# NとQの取得
index = 0
N = int(data[index])
index += 1
Q = int(data[index])
index += 1

# 文字列Sの取得
S = list(data[index])
index += 1

# クエリの取得
queries = []
for _ in range(Q):
    X = int(data[index])
    C = data[index + 1]
    index += 2
    queries.append((X, C))

# "ABC" の初期カウントを取得する関数
def count_abc(s):
    count = 0
    for i in range(len(s) - 2):
        if s[i:i + 3] == ['A', 'B', 'C']:
            count += 1
    return count

# 初期の "ABC" のカウント
abc_count = count_abc(S)

# クエリごとに処理する
results = []
for X, C in queries:
    X -= 1  # 0-indexed に変換

    # 置き換え前の周辺 "ABC" のカウントを減らす
    for i in range(max(0, X - 2), min(N - 2, X) + 1):
        if S[i:i + 3] == ['A', 'B', 'C']:
            abc_count -= 1
    
    # 文字列の変更
    S[X] = C

    # 置き換え後の周辺 "ABC" のカウントを増やす
    for i in range(max(0, X - 2), min(N - 2, X) + 1):
        if S[i:i + 3] == ['A', 'B', 'C']:
            abc_count += 1
    
    # 結果を保存
    results.append(abc_count)

# 結果の出力
sys.stdout.write("\n".join(map(str, results)) + "\n")
