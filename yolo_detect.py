from ultralytics import YOLO
import sys
import os
import shutil

def main():
    if len(sys.argv) < 2:
        print("Error: No image path provided.")
        return
    image_path = sys.argv[1]

    # check the image
    if not os.path.exists(image_path):
        print("Error: The provided image path does not exist.")
        return

    # upload model file
    model_path = r"C:\Users\dptos\source\repos\designProject\designProject\yoloModels\yolov8_best.pt"
    if not os.path.exists(model_path):
        print("Error: The model file does not exist.")
        return

    # create file name and target folder
    image_name = os.path.basename(image_path)  # for example: "happy-photo.jpg"
    detected_dir = os.path.join(os.path.dirname(__file__), "detected_images")
    os.makedirs(detected_dir, exist_ok=True)  # create folder if it doesn't exist

    model = YOLO(model_path)

    results = model.predict(source=image_path, save=True)

    # the folder where yolo saves the output 
    save_dir = results[0].save_dir
    saved_output_path = os.path.join(save_dir, image_name)  # YOLO's saved file path
    target_output_path = os.path.join(detected_dir, image_name)  # target file path

    # check the output file and move
    if os.path.exists(saved_output_path):
        shutil.move(saved_output_path, target_output_path)
        print(target_output_path)
    else:
        print(f"Error: Output file not found in {save_dir}. Check YOLO execution.")


if __name__ == "__main__":
    main()
