## الگوریتم TWR

درالگوریتم TWR زمان ارسال سیگنال UWB RF را اندازه می‌گیریم و فاصله بین دو نود را با ضرب این زمان در سرعت نور به دست می‌آوریم.

برای محاسبه فاصله سه پیام باید ارسال گردد:
- شروع کار با Tag است که TWR را با فرستان پیام poll به آدرس مشخص Anchor آغاز می‌کند. زمان این حرکت آغازین به Time of Sending Poll (TSP) موسوم است.
- در مرحله بعدی Anchor زمان دریافت poll را ذخیره می‌کند Time of Recieving Poll (TRP) و با پیام response در زمان Time of Sending Response (TSR) کار را ادامه می‌دهد.
- با رسیدن response به Tag زمان Time of Recieving Response (TRR) را ذخیره می‌کند و پیام نهایی را ارسال می‌کند که شامل ID, TSP, TRR, TSF می‌باشد.

در نهایت Anchor با استفاده از Time of Reception of Final message (TRF) و اطلاعات موجود در پیام آخر زمان پرواز سیگنال UWB را مشخص می‌سازد.
<p align="center">
<img width="376" alt="Screenshot 1404-01-26 at 11 02 48" src="https://github.com/user-attachments/assets/d40b997c-cd7f-46e5-9f87-937eb9b900b4" />
</p>
