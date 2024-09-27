import pypyjit
pypyjit.set_param('max_unroll_recursion=-1')

# 入力の読み込み
S = input().strip()

# ドットを削除
result = S.replace('.', '')

# 結果の出力
print(result)
