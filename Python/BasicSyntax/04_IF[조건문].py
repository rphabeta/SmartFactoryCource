# #------------------------------------------------------------------------------
# # 조건문
# # 분기문
# # . 조건에 따라 로직의 흐름을 나눌 수 있다.(제어, 컨트롤)
# # . 조건의 진위(참/거짓)의 여부에 따라 명령의 실행 여부를 결정한다.
# #------------------------------------------------------------------------------

# # if의 기본문법
# age = 19
# if age < 20:
#     print("안녕하세요")
#     print("미성년자이시군요")


# # 비교 연산자와 if 분기문의 사용 예시
# message = int(input("숫자를 입력하세요"))
# value = int(message)
# if value == 5:
#     print("5입니다.")
# if value > 5:
#     print("5 초과합니다")
# if value < 5:
#     print("5 미만입니다")

# # 순서상 뒤쪽으로 배치되는 문자(문자 코드)는 큰 것으로 판단
# if "A" > "a":
#     print("대문자 A가 더 큽니다")
# if "A" < "a":
#     print("소문자 a가 더 큽니다.")

# if "Aling" < "Beaute":
#     print("Beaute가 후순위에 있는 문자입니다")

# # != : 다르다 이소 만족하면 True를 반환
# if 4 != 5:
#     print("4와 5는 다릅니다.")


# # 논리연산자
# # 두 개 이상의 조건을 동시에 비교할 경우 사용
# value = int(input("숫자를 입력하세요"))
# if value > 0 and value <= 10:
#     print("1 과 10 사이에 있는 수 입니다.")
# if value > 10 or value <= 0:
#     print("1과 10 사이에 있는 수가 아닙니다.")


# # 아래와 같이 표현할 수 있다.
# value = int(input("숫자를 입력하세요"))
# if 0 < value <= 10:
#     print("1 과 10 사이에 있는 수 입니다.")

# # 논리연산자 not의 사용 예시
# # value가 0일 경우 비교 연산자를 통해 True가 되지만 not을 만나 False로 스위칭된다.
# # False 조건이므로 매세지가 출력되지 않는다.
# value = int(input("숫자를 입력하세요"))
# if not value == 0:
#     print("0이 아닙니다.")



# #------------------------------------------------------------------------------
# # In과 Not In
# # 포함되어 있는지 확인
# #------------------------------------------------------------------------------
# message = "안녕하세요"
# if "안" in message:
#     print("문자 \"안\"은 포함되어 있습니다.")
# if "." not in message:
#     print("문자 \".\"은 포함되어있지 않습니다.")
    

# #------------------------------------------------------------------------------
# # 코드 블럭과 n개의 분기 흐름 제어
# # - 블럭 단위
# #   . 컴퓨터가 코드를 수행하는 단위
# #   . 분기문의 경우 해당 조건에 따른 로직이 나뉘어지고 블럭 단위의 로직을 수행하게 된다.
# #   . 파이썬 언어는 들여쓰기로 블럭을 표현한다.
# #------------------------------------------------------------------------------
# # 메인 코드의 흐름을 두 가지 분기로 나누어 하나만 실행 할 수 있도록 제어
# number = input("번호를 입력하세요")
# if number == "12345":
#     print("1등입니다.")
# else :
#     print("꽝 입니다.")

# print("출근 준비")

# # elif 
# # 상위 분기 결과가 False일 경우 그 나머지 경우 중 조건을 만족하는 경우의 로직을 수행하도록 
# # 제어하는 기능
# number = input("번호를 입력하세요")

# if number == "12345":
#     print("1등입니다.")
# elif number == "123456"   
#     print("2등입니다")
# else:
#     print("꽝 입니다.")

# print("출근 준비")

# # if 문의 중첩
# # if 문 내에 분기의 흐름을 N개 생성 할 수 있다.
# # * 너무 많은 if문을 중첩할 경우 코드가 복잡해지고 가독성이 떨어질 수 있다.
# number = input("번호를 입력하세요 : ")

# if number == "12345":
#     print("1등입니다.")
# elif number == "123456":
#     print("2등입니다")
# else:
#     bonus = input("보너스 번호를 입력 : ")
#     if bonus == "123458":
#         print("3등입니다.")
#     else: 
#         print("꽝 입니다.")

# print("출근 준비")

# #------------------------------------------------------------------------------
# # 실습
# # dir 변수 에는 '동', '서', '남', '북' 넷 중 하나의 방향 값이 들어간다. 
# # 이 변수의 값에 따라 우리나라에서 각 방향에 있는 지명 하나를 출력하는 로직을 구현해 보세요
# #------------------------------------------------------------------------------
# dir = input("방향을 입력하세요 : ")
# if dir == '북':
#     print("서울")
# elif dir == '남':
#     print("울산")
# elif dir == '서':
#     print("인천")
# elif dir == '동':
#     print("속초")
# else:
#     print("방향을 다시 입력하세요!")


# #------------------------------------------------------------------------------
# # 실습
# #  정수 를 입력 받아 5의 배수 인지 확인하는 로직을 구현하세요
# #------------------------------------------------------------------------------
# iValue = int(input("정수를 입력하세요: "))
# if iValue % 5 == 0:
#     print(iValue, "는 5의 배수입니다.", sep="")
# else :
#     print(iValue, "는 5의 배수가 아닙니다.", sep="")


# #------------------------------------------------------------------------------
# # 실습
# # 서울 우유 는 1리터에 2500 원이고 매일우유는 1.8 리터에 4200 원 이다.
# # 용량대비 어떤 우유가 더 싼 가격인지 판단하여 결과를 출력 해 보세요
# #------------------------------------------------------------------------------
# SeoulLPerWon = 2500 / 1.0
# MailLPerWon = 4200 / 1.8
# if (SeoulLPerWon == MailLPerWon):
#     print("L당 가격이 동일합니다.")
# elif (SeoulLPerWon > MailLPerWon):
#     print("메일우유가 L당", SeoulLPerWon - MailLPerWon, "원 더 쌉니다.", sep="")
# else:
#     print("서울우유가 L당", MailLPerWon - SeoulLPerWon, "원 더 쌉니다.", sep="")


